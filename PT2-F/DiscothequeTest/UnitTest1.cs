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
                Utils.Connexion.SaveChanges().GetAwaiter().GetResult();

                var result = from data in Utils.Connexion.ABONNÉS
                             where data.LOGIN_ABONNÉ == "TestRegister"
                             select data.CODE_ABONNÉ;

                //Assert.IsFalse(Utils.GetABONNÉ(result.FirstOrDefault()).CODE_ABONNÉ==abo.CODE_ABONNÉ);
                Assert.IsTrue(result.FirstOrDefault() == 0);
            }

            //On ajoute un abonné
            ABONNÉS a = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1).GetAwaiter().GetResult();

            //On regarde si il a bien etait crée
            Assert.IsNotNull(a);

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
                        where aboGetId.LOGIN_ABONNÉ == "TestRegister"
                        select aboGetId.CODE_ABONNÉ;

            if (aboId.Count() == 0)
            {
                ABONNÉS a = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1).GetAwaiter().GetResult();
                Assert.IsNotNull(a);
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

                Assert.IsTrue(e.CODE_ALBUM == i);
            }

            var abonneSup = from aboGetId in Utils.Connexion.ABONNÉS
                            where aboGetId.LOGIN_ABONNÉ == "TestRegister"
                            select aboGetId.CODE_ABONNÉ;

            SuppAboAfterTests(Utils.GetABONNÉ(abonneSup.FirstOrDefault()));
        }

        /// <summary>
        /// US2
        /// </summary>
        [TestMethod]
        public void TestUS2()
        {
            Random rand = new Random();

            // si l'abonné existe deja, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus2")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges().GetAwaiter().GetResult();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US2", "tus2", "mdpGIGAStrong", 45).GetAwaiter().GetResult();

            Assert.IsTrue(abo != null);

            // On effectue une dizaines d'emprunts tests
            for (int i = 50; i <= 80; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                EMPRUNTER e = abo.Emprunter(alToTake).GetAwaiter().GetResult();
            }

            // On recupère ses emprunts, et on vérifie que tout les emprunts fait precedemment sont là
            Dictionary<EMPRUNTER, ALBUMS> emprunts = abo.ConsulterEmprunts();

            for (int i = 50; i <= 80; i++)
            {
                Assert.IsTrue(emprunts.Values.Any(album => (album.CODE_ALBUM == i)));
            }

            SuppAboAfterTests(abo);
        }

        /// <summary>
        /// US3
        /// </summary>
        [TestMethod]
        public void TestUS3()
        {
            Random rand = new Random();

            // si l'abonné existe deja, on le supprime
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

            Assert.IsTrue(dateApresProlong == dateApresSecondProlong);

            Assert.IsTrue(abo != null);

            //SuppAboAfterTests(abo);
        }

        /// <summary>
        /// US4
        /// </summary>
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
                           && emp.CODE_ABONNÉ == abo.CODE_ABONNÉ
                           select emp).FirstOrDefault();

            Console.WriteLine("dubdpuibb      " + e);

            // On recupère tout les emprunts prolongés 
            IQueryable<EMPRUNTER> prolongésBefore = Utils.AvoirLesEmpruntProlonger();

            foreach (EMPRUNTER emp in prolongésBefore)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("-------------------------------------------");


            // On verifie que ce nouvel emprunt n'y es pas
            Assert.IsFalse(prolongésBefore.Any(emprunt => (emprunt.CODE_ABONNÉ == e.CODE_ABONNÉ) && (emprunt.CODE_ALBUM == e.CODE_ALBUM)));

            // On prolonge l'emprunt
            bool prolong = abo.ProlongerEmprunt(alToTake).GetAwaiter().GetResult();

            Assert.IsTrue(prolong);

            // On vérifie qu'il fait maintenant partie des emprunts prolongés
            IQueryable<EMPRUNTER> prolongésAfter = Utils.AvoirLesEmpruntProlonger();

            foreach (EMPRUNTER empr in prolongésAfter)
            {
                Console.WriteLine(empr);
            }

            Assert.IsTrue(prolongésAfter.Any(emprunt => (emprunt.CODE_ABONNÉ == e.CODE_ABONNÉ) && (emprunt.CODE_ALBUM == e.CODE_ALBUM)));

            SuppAboAfterTests(abo);

        }

        [TestMethod]
        public void TestUS5()
        {
            // si l'abonné existe deja, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus5")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges().GetAwaiter().GetResult();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US5", "tus5", "mdpTRESStrong", 45).GetAwaiter().GetResult();

            Assert.IsTrue(abo != null);

            // On effectue quelques emprunts tests
            for (int i = 110; i < 120; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                EMPRUNTER e = abo.Emprunter(alToTake).GetAwaiter().GetResult();
            }

            // On vérifie que l'abonné n'est pas pour l'instant en retard
            IQueryable<ABONNÉS> abonnesEnRetard = Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();
            Assert.IsFalse(abonnesEnRetard.Any(abonne => abonne.CODE_ABONNÉ == abo.CODE_ABONNÉ));

            // On fait un emprunt pour l'abonné avec une date de retour qui correspondra forcement à un retard
            ALBUMS alb = (from ab in Utils.Connexion.ALBUMS
                          where ab.CODE_ALBUM == 125
                          select ab).FirstOrDefault();

            Assert.IsTrue(alb != null);

            EMPRUNTER emp = abo.Emprunter(alb).GetAwaiter().GetResult();

            Assert.IsNotNull(emp);

            emp.DATE_RETOUR_ATTENDUE = DateTime.Now.AddDays(-100);

            // On vérifie maintenant que l'abonné fait partie des abonnés en retard 
            IQueryable<ABONNÉS> abonnesEnRetardApres = Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();
            Assert.IsFalse(abonnesEnRetardApres.Any(abonne => abonne.CODE_ABONNÉ == abo.CODE_ABONNÉ));
        }



        /// <summary>
        /// US6 Purge les abonées qui ont pas emprunté depuis un an
        /// </summary>
        [TestMethod]
        public void TestPurgerAbonneInactif()
        {
            //DEPART DE PREP POUR PURGER ABO
            AddAboForTests("Register", "Test", "TestRegister", "123456", 1);
            var initState = from getAboNew in Utils.Connexion.ABONNÉS
                            where getAboNew.LOGIN_ABONNÉ == "TestRegister"
                            select getAboNew.CODE_ABONNÉ;

            ABONNÉS abonne = Utils.GetABONNÉ(initState.FirstOrDefault());

            abonne.creationDate = DateTime.Now.AddDays(-400);
            abonne.CODE_PAYS = 5;
            idAboTest = abonne.CODE_ABONNÉ;
            Utils.Connexion.SaveChanges().GetAwaiter().GetResult();

            var middleState = from abFinal in Utils.Connexion.ABONNÉS
                              where abFinal.LOGIN_ABONNÉ == "TestRegister"
                              select abFinal.CODE_ABONNÉ;

            abonne = Utils.GetABONNÉ(middleState.FirstOrDefault());

            ALBUMS alb = (from ab in Utils.Connexion.ALBUMS
                          where ab.CODE_ALBUM == 20
                          select ab).FirstOrDefault();

            Assert.IsTrue(alb != null);

            EMPRUNTER e = abonne.Emprunter(alb).GetAwaiter().GetResult();

            Assert.IsNotNull(e);

            e.DATE_EMPRUNT = DateTime.Now.AddDays(-390);
            Utils.Connexion.SaveChanges().GetAwaiter().GetResult();
            //FIN DE PREP

            var abo = Utils.SupprimerAbosPasEmpruntDepuisUnAn().GetAwaiter().GetResult();

            foreach (ABONNÉS a in abo)
            {
                ABONNÉS aboneSupp = Utils.GetABONNÉ(a.CODE_ABONNÉ);
                if (abo != null)
                {
                    Console.WriteLine("abonne sup = " + a.LOGIN_ABONNÉ);
                    Assert.IsTrue(a.LOGIN_ABONNÉ == "TestRegister");
                }

            }
            try
            {
                SuppAboAfterTests(abonne);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("abo deja supprimer");
            }

        }

        private static void AddAboForTests(string nom, string prenom, string login, string mdp, int codePays)
        {
            Utils.RegisterAbo(nom, prenom, login, mdp, codePays).GetAwaiter().GetResult();
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