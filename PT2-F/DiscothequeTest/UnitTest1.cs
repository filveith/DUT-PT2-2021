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
        
        /// <summary>
        /// US1
        /// </summary>
        [TestMethod]
        public void TestAjoutAbonnée()
        { 
            /*AddAboForTests("Register", "Test", "TestRegister", "123456", 1);

            var finalState = from user in Utils.Connexion.ABONNÉS
                             where user.LOGIN_ABONNÉ == "TestRegister"
                             select user.CODE_ABONNÉ;

            Console.WriteLine(finalState.FirstOrDefault());

            ABONNÉS abo = Utils.GetABONNÉ(finalState.FirstOrDefault());

            Console.WriteLine(abo.LOGIN_ABONNÉ + "         " + abo.CODE_ABONNÉ);

            Assert.IsTrue(abo.LOGIN_ABONNÉ.Trim().Equals("TestRegister"));

            Utils.Connexion.SaveChanges();*/



            var initState = (from data in Utils.Connexion.ABONNÉS
                             where data.LOGIN_ABONNÉ.Equals("TestRegister")
                             select data.CODE_ABONNÉ);

            //On passse si l'abonné TestRegister n'existe pas
            if (initState.Count() != 0)
            {
                Console.WriteLine("abo existe pas");

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
                             where data.LOGIN_ABONNÉ == "TestRegister"
                             select data.CODE_ABONNÉ;

                //Assert.IsFalse(Utils.GetABONNÉ(result.FirstOrDefault()).CODE_ABONNÉ==abo.CODE_ABONNÉ);
                Assert.IsTrue(result.FirstOrDefault() == 0);
            }

            //On ajoute un abonné
            bool t = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1).GetAwaiter().GetResult();

            //On regarde si il a bien etait crée
            Assert.IsTrue(t);

            var finalResult = from data in Utils.Connexion.ABONNÉS
                              where data.LOGIN_ABONNÉ.Equals("TestRegister")
                              select data.CODE_ABONNÉ;

            ABONNÉS aboFinal = Utils.GetABONNÉ(finalResult.FirstOrDefault());

            //On verifie avec la base de données si il existe bien
            Assert.IsTrue(aboFinal.LOGIN_ABONNÉ == "TestRegister");
            idAboTest = aboFinal.CODE_ABONNÉ;

            SuppAboAfterTests(Utils.GetABONNÉ(aboFinal.CODE_ABONNÉ));
        }

        /// <summary>
        /// US1
        /// </summary>
        [TestMethod]
        public void TestAjoutEmprunt()
        {
            var aboId = from aboGetId in Utils.Connexion.ABONNÉS
                        where aboGetId.LOGIN_ABONNÉ=="TestRegister"
                        select aboGetId.CODE_ABONNÉ;

            if(aboId.Count() == 0)
            {
                bool t = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1).GetAwaiter().GetResult();
                Assert.IsTrue(t);
            }

            idAboTest = Utils.GetABONNÉ(aboId.FirstOrDefault()).CODE_ABONNÉ;

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

            abo.CODE_ABONNÉ = Utils.GetABONNÉ(aboId.FirstOrDefault()).CODE_ABONNÉ;

            // On effectue une dizaines d'emprunts tests
            for (int i = 86; i < 106; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);

                EMPRUNTER e = abo.Emprunter(alToTake).GetAwaiter().GetResult();
                Assert.IsNotNull(e);
                //Console.WriteLine(e);

                Assert.IsTrue(e.CODE_ALBUM==i);
            }

            var abonneSup = from aboGetId in Utils.Connexion.ABONNÉS
                        where aboGetId.LOGIN_ABONNÉ == "TestRegister"
                        select aboGetId.CODE_ABONNÉ;

            SuppAboAfterTests(Utils.GetABONNÉ(abonneSup.FirstOrDefault()));
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
            Utils.Connexion.SaveChanges().GetAwaiter().GetResult();
        }
    }
}