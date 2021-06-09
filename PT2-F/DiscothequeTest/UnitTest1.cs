using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace DiscothequeTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestUS3()
        {
            Random rand = new Random();


            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus3")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges().GetAwaiter().GetResult();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US3", "tus3", "mdpStrong", 45).GetAwaiter().GetResult();

            Assert.IsTrue(abo != null);


            // On effectue une dizaines d'emprunts tests
            for (int i = 86; i < 106; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                EMPRUNTER e = abo.Emprunter(alToTake).GetAwaiter().GetResult();
            }
            
           

            
            // On recupère ses emprunts, et on choisit un emprunt et l'album à prolonger au hasard
            Dictionary<EMPRUNTER, ALBUMS> emprunts = abo.ConsulterEmprunts();
            int randIndex = rand.Next(0, emprunts.Count);
            Console.WriteLine(emprunts.ElementAt(randIndex));
            ALBUMS al = emprunts.ElementAt(randIndex).Value;
            EMPRUNTER emprunt = emprunts.ElementAt(randIndex).Key;

            
            // On vérifie que la date avant changement est differente de celle après changement, d'exactement 1 mois
            DateTime dateAvantProlong = emprunt.DATE_RETOUR_ATTENDUE;

            abo.ProlongerEmprunt(al).GetAwaiter().GetResult();

            DateTime dateApresProlong = emprunt.DATE_RETOUR_ATTENDUE;

            Assert.IsTrue(dateAvantProlong != dateApresProlong);
            Assert.IsTrue(dateApresProlong == dateAvantProlong.AddMonths(1));

            // On vérifie qu'on ne peut pas prolonger un emprunt déjà emprunté

            abo.ProlongerEmprunt(al).GetAwaiter().GetResult();

            DateTime dateApresSecondProlong = emprunt.DATE_RETOUR_ATTENDUE;

            Assert.IsFalse(dateApresProlong != dateApresSecondProlong);

            Assert.IsTrue(abo != null);

        }

        [TestMethod]
        public void TestUS4()
        {
            Random rand = new Random();

            // si l'abonné existe deja, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus4")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges().GetAwaiter().GetResult();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US4", "tus4", "mdpStrong", 45).GetAwaiter().GetResult();

            Assert.IsTrue(abo != null);

            // On emprunte un album au hasard 
            int i = rand.Next(80, 150);

            ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                               where ab.CODE_ALBUM == i
                               select ab).FirstOrDefault();

            Assert.IsTrue(alToTake != null);


            abo.Emprunter(alToTake).GetAwaiter().GetResult();

            EMPRUNTER e = (from emp in Utils.Connexion.EMPRUNTER
                           where emp.CODE_ALBUM == alToTake.CODE_ALBUM
                           select emp).FirstOrDefault();

            Console.WriteLine("dubdpuibb      "  + e);

            // On recupère tout les emprunts prolongés 
            IQueryable<EMPRUNTER> prolongésBefore = Utils.AvoirLesEmpruntProlonger();

            // On verifie que ce nouvel emprunt n'y es pas
            Assert.IsFalse(prolongésBefore.Any(emprunt => (emprunt.CODE_ABONNÉ == e.CODE_ABONNÉ) && (emprunt.CODE_ALBUM == e.CODE_ALBUM)));

            // On prolonge l'emprunt
            bool prolong = abo.ProlongerEmprunt(alToTake).GetAwaiter().GetResult();

            Assert.IsTrue(prolong);

            // On vérifie qu'il fait maintenant partie des emprunts prolongés
            IQueryable<EMPRUNTER> prolongésAfter = Utils.AvoirLesEmpruntProlonger();
            Assert.IsTrue(prolongésAfter.Any(emprunt => (emprunt.CODE_ABONNÉ == e.CODE_ABONNÉ) && (emprunt.CODE_ALBUM == e.CODE_ALBUM)));

            SuppAboAfterTests(abo);
        }


        private static void AddAboForTests(string nom, string prenom, string login, string mdp, int codePays)
        {
            _ = Utils.RegisterAbo(nom, prenom, login, mdp, codePays);
        }

        private static void SuppAboAfterTests(ABONNÉS abo)
        {
            foreach (EMPRUNTER emprunt in Utils.Connexion.EMPRUNTER)
            {
                if (emprunt.CODE_ABONNÉ == abo.CODE_ABONNÉ)
                {
                    Utils.Connexion.EMPRUNTER.Remove(emprunt);
                }
            }

            Utils.Connexion.ABONNÉS.Remove(abo);
        }

    }
}