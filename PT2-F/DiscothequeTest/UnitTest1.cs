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
        private int idAboTest = 0;
        

        [TestMethod]
        public void TestAjoutAbonnée()
        {
            AddAboForTests("Register", "Test", "TestRegister", "123456", 1);

            var finalState = from user in Utils.Connexion.ABONNÉS
                             where user.LOGIN_ABONNÉ == "TestRegister"
                             select user.CODE_ABONNÉ;

            Console.WriteLine(finalState.FirstOrDefault());

            ABONNÉS abo = Utils.GetABONNÉ(finalState.FirstOrDefault());

            Console.WriteLine(abo.LOGIN_ABONNÉ + "         " + abo.CODE_ABONNÉ);

            Assert.IsTrue(abo.LOGIN_ABONNÉ.Trim().Equals("TestRegister"));

            /*var initState = (from data in Utils.Connexion.ABONNÉS
                            where data.LOGIN_ABONNÉ.Equals("TestRegister")
                            select data.CODE_ABONNÉ);

            //On passse si l'abonné TestRegister n'existe pas
            if (initState.Count() != 0)
            {
                //Create an ABONNE object
                ABONNÉS abo = Utils.GetABONNÉ(initState.FirstOrDefault());

                //On supprime l'abonné si il existe 
                var emprunts = (from e in Utils.Connexion.EMPRUNTER
                                where e.CODE_ABONNÉ == abo.CODE_ABONNÉ
                                select e);

                Utils.Connexion.EMPRUNTER.RemoveRange(emprunts);
                Utils.Connexion.ABONNÉS.Remove(abo);
                Utils.Connexion.SaveChanges();

                var result = from data in Utils.Connexion.ABONNÉS
                            where data.LOGIN_ABONNÉ=="TestRegister"
                            select data.CODE_ABONNÉ;

                //Assert.IsFalse(Utils.GetABONNÉ(result.FirstOrDefault()).CODE_ABONNÉ==abo.CODE_ABONNÉ);
                Assert.IsTrue(result.FirstOrDefault() == 0);
            }

            //On ajoute un abonné
            bool t = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1);

            //On regarde si il a bien etait crée
            Assert.IsTrue(t);

            var finalResult = from data in Utils.Connexion.ABONNÉS
                         where data.LOGIN_ABONNÉ.Equals("TestRegister")
                         select data.CODE_ABONNÉ;

            ABONNÉS aboFinal = Utils.GetABONNÉ(finalResult.FirstOrDefault());

            //On verifie avec la base de données si il existe bien
            Assert.IsTrue(aboFinal.LOGIN_ABONNÉ=="TestRegister");
            idAboTest = aboFinal.CODE_ABONNÉ;*/
        }

        [TestMethod]
        public void TestAjoutEmprunt()
        {
            var initState = from em in Utils.Connexion.EMPRUNTER
                            where em.CODE_ABONNÉ == idAboTest
                            select em;

            foreach (EMPRUNTER em in initState)
            {
                var emprunts = (from emp in Utils.Connexion.EMPRUNTER
                                where emp.CODE_ABONNÉ == idAboTest
                                select emp);
                Utils.Connexion.EMPRUNTER.RemoveRange(emprunts);
            }

            ABONNÉS abo = new ABONNÉS();

            ALBUMS alb = new ALBUMS();

            abo.CODE_ABONNÉ = idAboTest;

            //On ajoute les albums avec l'id 86 jusqu'à l'id 105 (pour avoir differents type de genres)
            for (int i=86; i<105; i++)
            {
                var album = (from albumEmprunt in Utils.Connexion.ALBUMS
                            where albumEmprunt.CODE_ALBUM == i
                            select albumEmprunt.CODE_ALBUM);
                
                var retour = abo.Emprunter(Utils.GetALBUM(album.FirstOrDefault()));

                //Si l'album n'est pas ajouter a la base on stop le test
                Assert.IsNotNull(retour);
            }

            var finalState = from emFinal in Utils.Connexion.EMPRUNTER
                             where emFinal.CODE_ABONNÉ == idAboTest
                             select emFinal;
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