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
        /*[TestMethod]
        public void TestAjoutAbonnée()
        {
            var bdResult = (from data in Utils.Connexion.ABONNÉS
                           where data.LOGIN_ABONNÉ.Equals("TestRegister")
                           select data.CODE_ABONNÉ);

            //On passse si l'abonné TestRegister n'existe pas
            if(bdResult.Count() != 0)
            {
                //On supprime l'abonné si il existe 
                var emprunts = (from e in Utils.Connexion.EMPRUNTER
                                where e.CODE_ABONNÉ == bdResult.FirstOrDefault()
                                select e);
                Utils.Connexion.EMPRUNTER.RemoveRange(emprunts);
                Utils.Connexion.ABONNÉS.Remove(Utils.GetABONNÉ(bdResult.FirstOrDefault()));

                //Assert.IsFalse(Utils.GetABONNÉ(bdResult.CODE_ABONNÉ).LOGIN_ABONNÉ.Equals(bdResult.LOGIN_ABONNÉ));
                Assert.IsFalse(Utils.GetABONNÉ(bdResult.FirstOrDefault()).CODE_ABONNÉ.Equals(bdResult.FirstOrDefault()));
            }

            //On ajoute un abonné
            bool t = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1);

            //On regarde si il a bien etait cree
            Assert.IsTrue(t);

            var result = from data in Utils.Connexion.ABONNÉS
                       where data.LOGIN_ABONNÉ.Equals("TestRegister")
                       select data.CODE_ABONNÉ;

            //On verifie avec la base de données si il existe bien
            Assert.IsTrue(Utils.GetABONNÉ(result.FirstOrDefault()).LOGIN_ABONNÉ.Equals("TestRegister"));
        }*/

        [TestMethod]
        public void TestUS3()
        {
            Random rand = new Random();


            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus3")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                Utils.Connexion.ABONNÉS.Remove(abo);
            }

            // On crée un abonné pour nos tests
            AddAboForTests("Test", "US3", "tus3", "mdpstrong", 22);
            

            Assert.IsTrue(abo != null);

            // On effectue une dizaines d'emprunts tests
            
            //abo.Emprunter(Utils.Connexion.ALBUMS.OrderBy(r => Guid.NewGuid()).Skip(rand.Next(1, Utils.Connexion.ALBUMS.Count())).Take(1).First());


            /*
            // On recupère ses emprunts, et on choisit un emprunt et l'album à prolonger au hasard
            Dictionary<EMPRUNTER, ALBUMS> emprunts = abo.ConsulterEmprunts();
            int randIndex = rand.Next(0, emprunts.Count);
            ALBUMS al = emprunts.ElementAt(randIndex).Value;
            EMPRUNTER emprunt = emprunts.ElementAt(randIndex).Key;


            // On vérifie que la date avant changement est differente de celle après changement, d'exactement 1 mois
            DateTime dateAvantProlong = emprunt.DATE_RETOUR_ATTENDUE;

            abo.ProlongerEmprunt(al);

            DateTime dateApresProlong = emprunt.DATE_RETOUR_ATTENDUE;

            Assert.IsTrue(dateAvantProlong != dateApresProlong);
            Assert.IsTrue(dateApresProlong == dateAvantProlong.AddMonths(1));

            // On vérifie qu'on ne peut pas prolonger un emprunt déjà emprunté

            abo.ProlongerEmprunt(al);

            DateTime dateApresSecondProlong = emprunt.DATE_RETOUR_ATTENDUE;

            Assert.IsFalse(dateApresProlong != dateApresSecondProlong);

            Assert.IsTrue(abo != null);*/

            /*suppAboAfterTests(abo);*/

        }


        private static void AddAboForTests(string nom, string prenom, string login, string mdp, int codePays)
        {
            Utils.RegisterAbo(nom, prenom, login, mdp, codePays);
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
