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
        public async void TestUS3()
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
            await Utils.RegisterAbo("Test", "US3", "tus3", "mdpStrong", 45);            

            Assert.IsTrue(abo != null);

            int ind = rand.Next(1, 50);
            // On effectue une dizaines d'emprunts tests
            ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                               where ab.CODE_ALBUM == ind
                               select ab).FirstOrDefault();

            await abo.Emprunter(alToTake);


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
