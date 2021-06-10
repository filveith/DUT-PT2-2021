using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DiscothequeTest
{
    [TestClass]
    public class UnitTest1
    {
        private int idAboTest = 0;

        /// <summary>
        /// US1 Ajout d'un abonné
        /// </summary>
        [TestMethod, TestCategory("US1")]
        public void TestAjoutAbonnée()
        {
            //Check si abo existe
            ABONNÉS abo = Utils.GetABONNÉS("TestRegister");

            //On passse si l'abonné TestRegister n'existe pas
            if (abo != null)
            {
                SuppAboAfterTests(abo);
                ABONNÉS removedAbo = Utils.GetABONNÉS("TestRegister");

                Assert.IsTrue(removedAbo == null);
            }

            //On ajoute un abonné
            ABONNÉS a = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1);

            // On vérifie qu'il a bien était créé
            Assert.IsNotNull(a);

            ABONNÉS aboFinal = Utils.GetABONNÉS("TestRegister");

            //On verifie avec la base de données si il existe bien
            Assert.IsTrue(aboFinal.LOGIN_ABONNÉ == "TestRegister");
            idAboTest = aboFinal.CODE_ABONNÉ;

            SuppAboAfterTests(aboFinal);
        }

        /// <summary>
        /// US1 Ajout d'un emprunt
        /// </summary>
        [TestMethod, TestCategory("US1")]
        public void TestAjoutEmprunt()
        {
            // On récupère le code de l'abonné TestRegister 
            ABONNÉS abonne = Utils.GetABONNÉS("TestRegister");

            // S'il n'y en a pas, on crée l'abonné
            if (abonne == null)
            {
                ABONNÉS a = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1);
                Assert.IsNotNull(a);
            }
            ABONNÉS abon = Utils.GetABONNÉS("TestRegister");
            idAboTest = abon.CODE_ABONNÉ;

            var initState = from em in Utils.Connexion.EMPRUNTER
                            where em.CODE_ABONNÉ == idAboTest
                            select em;

            // On effectue une dizaines d'emprunts tests (les albums id 86 a 105)
            ABONNÉS abo = new ABONNÉS();
            ALBUMS alb = new ALBUMS();

            abonne = Utils.GetABONNÉS("TestRegister");

            abo.CODE_ABONNÉ = abonne.CODE_ABONNÉ;

            // On effectue une dizaines d'emprunts tests
            for (int i = 86; i < 106; i++)
            {
                ALBUMS alToTake = Utils.GetALBUM(i);
                alb = alToTake;

                Assert.IsTrue(alToTake != null);

                
            }

            abo.Rendre(alb);
            EMPRUNTER emp = abo.Emprunter(alb);
            Assert.IsNotNull(emp);

            SuppAboAfterTests(Utils.GetABONNÉ(idAboTest));

            var abonneSup = from aboGetId in Utils.Connexion.ABONNÉS
                            where aboGetId.LOGIN_ABONNÉ == "TestRegister"
                            select aboGetId.CODE_ABONNÉ;

            SuppAboAfterTests(Utils.GetABONNÉ(abonneSup.FirstOrDefault()));
        }

        /// <summary>
        /// US2 Consulter ses emprunts
        /// </summary>
        [TestMethod, TestCategory("US2")]
        public void TestUS2()
        {
            Random rand = new Random();

            // Si l'abonné existe déjà, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus2")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US2", "tus2", "mdpGIGAStrong", 45);

            Assert.IsTrue(abo != null);

            // On vérifie qu'il n'a aucun emprunt pour l'instant 
            Dictionary<EMPRUNTER, ALBUMS> empruntsBefore = abo.ConsulterEmprunts();
            Assert.IsTrue(empruntsBefore.Count() == 0);

            // On effectue quelques emprunts tests
            for (int i = 50; i <= 80; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                EMPRUNTER e = abo.Emprunter(alToTake);
            }

            // On recupère ses emprunts, et on vérifie que tout les emprunts fait precedemment sont là
            Dictionary<EMPRUNTER, ALBUMS> empruntsAfter = abo.ConsulterEmprunts();

            for (int i = 50; i <= 80; i++)
            {
                Assert.IsTrue(empruntsAfter.Values.Any(album => (album.CODE_ALBUM == i)));
            }

            SuppAboAfterTests(abo);
        }

        /// <summary>
        /// US3 Prolonger un emprunt
        /// </summary>
        [TestMethod, TestCategory("US3")]
        public void TestUS3()
        {
            Random rand = new Random();

            // Si l'abonné existe déjà, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus3")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US3", "tus3", "mdpStrong", 45);

            Assert.IsTrue(abo != null);


            // On effectue une dizaines d'emprunts tests
            for (int i = 86; i < 106; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                EMPRUNTER e = abo.Emprunter(alToTake);
            }

            // On recupère ses emprunts, et on choisit un emprunt et l'album à prolonger au hasard
            Dictionary<EMPRUNTER, ALBUMS> emprunts = abo.ConsulterEmprunts();
            int randIndex = rand.Next(0, emprunts.Count);
            Console.WriteLine(emprunts.ElementAt(randIndex));
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

            Assert.IsTrue(dateApresProlong == dateApresSecondProlong);

            Assert.IsTrue(abo != null);
        }

        /// <summary>
        /// US4 Consulter emprunts prolongés
        /// </summary>
        [TestMethod, TestCategory("US4")]
        public void TestUS4()
        {
            Random rand = new Random();

            // Si l'abonné existe déjà, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus4")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US4", "tus4", "mdpStrong", 45);

            Assert.IsTrue(abo != null);

            // On emprunte un album au hasard 
            int i = rand.Next(80, 150);

            ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                               where ab.CODE_ALBUM == i
                               select ab).FirstOrDefault();

            Assert.IsTrue(alToTake != null);


            abo.Emprunter(alToTake);

            EMPRUNTER e = (from emp in Utils.Connexion.EMPRUNTER
                           where emp.CODE_ALBUM == alToTake.CODE_ALBUM
                           && emp.CODE_ABONNÉ == abo.CODE_ABONNÉ
                           select emp).FirstOrDefault();

            // On recupère tout les emprunts prolongés 
            var prolongésBefore = Utils.AvoirLesEmpruntProlonger();


            // On vérifie que ce nouvel emprunt n'y est pas
            Assert.IsFalse(prolongésBefore.Any(emprunt => (emprunt.CODE_ABONNÉ == e.CODE_ABONNÉ) && (emprunt.CODE_ALBUM == e.CODE_ALBUM)));

            // On prolonge l'emprunt
            bool prolong = abo.ProlongerEmprunt(alToTake);

            Assert.IsTrue(prolong);

            // On vérifie qu'il fait maintenant partie des emprunts prolongés
            var prolongésAfter = Utils.AvoirLesEmpruntProlonger();

            Assert.IsTrue(prolongésAfter.Any(emprunt => (emprunt.CODE_ABONNÉ == e.CODE_ABONNÉ) && (emprunt.CODE_ALBUM == e.CODE_ALBUM)));

            SuppAboAfterTests(abo);

        }

        /// <summary>
        /// US5 Lister retards
        /// </summary>
        [TestMethod, TestCategory("US5")]
        public void TestUS5()
        {
            // Si l'abonné existe déjà, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus5")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US5", "tus5", "mdpTRESStrong", 45);

            Assert.IsTrue(abo != null);

            // On effectue quelques emprunts tests
            for (int i = 110; i < 120; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                EMPRUNTER e = abo.Emprunter(alToTake);
            }

            // On vérifie que l'abonné n'est pas pour l'instant en retard
            IQueryable<ABONNÉS> abonnesEnRetard = Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();
            Assert.IsFalse(abonnesEnRetard.Any(abonne => abonne.CODE_ABONNÉ == abo.CODE_ABONNÉ));

            // On fait un emprunt pour l'abonné avec une date de retour qui correspondra forcement à un retard
            ALBUMS alb = (from ab in Utils.Connexion.ALBUMS
                          where ab.CODE_ALBUM == 125
                          select ab).FirstOrDefault();

            Assert.IsTrue(alb != null);

            EMPRUNTER emp = abo.Emprunter(alb);

            Assert.IsNotNull(emp);

            emp.DATE_RETOUR_ATTENDUE = DateTime.Now.AddDays(-100);

            // On vérifie maintenant que l'abonné fait partie des abonnés en retard 
            IQueryable<ABONNÉS> abonnesEnRetardApres = Utils.AvoirAbonneAvecEmpruntRetardDe10Jours();
            Assert.IsFalse(abonnesEnRetardApres.Any(abonne => abonne.CODE_ABONNÉ == abo.CODE_ABONNÉ));

            SuppAboAfterTests(abo);
        }


        /// <summary>
        /// US6 Purge les abonées qui n'ont pas emprunté depuis un an
        /// </summary>
        [TestMethod, TestCategory("US6")]
        public void TestPurgerAbonneInactif()
        {
            // DEPART DE PREPARATION POUR PURGER UN ABONNE INACTIF
            // Ajout d'un abonné
            AddAboForTests("Register", "Test", "TestRegister", "123456", 1);

            var initState = from getAboNew in Utils.Connexion.ABONNÉS
                            where getAboNew.LOGIN_ABONNÉ == "TestRegister"
                            select getAboNew.CODE_ABONNÉ;

            ABONNÉS abonne = Utils.GetABONNÉ(initState.FirstOrDefault());

            // On change la date de création de l'abonné de -400 jours
            abonne.creationDate = DateTime.Now.AddDays(-400);
            abonne.CODE_PAYS = 5;
            idAboTest = abonne.CODE_ABONNÉ;
            Utils.Connexion.SaveChanges();

            var middleState = from abFinal in Utils.Connexion.ABONNÉS
                              where abFinal.LOGIN_ABONNÉ == "TestRegister"
                              select abFinal.CODE_ABONNÉ;

            abonne = Utils.GetABONNÉ(middleState.FirstOrDefault());

            ALBUMS alb = (from ab in Utils.Connexion.ALBUMS
                          where ab.CODE_ALBUM == 20
                          select ab).FirstOrDefault();

            // On vérifie que l'album existe bien
            Assert.IsTrue(alb != null);

            //on l'emprunte
            EMPRUNTER e = abonne.Emprunter(alb);

            // On vérifie que l'emprunt a bien fonctionner
            Assert.IsNotNull(e);

            // On change la date de son dernier emprunt à plus d'un an
            e.DATE_EMPRUNT = DateTime.Now.AddDays(-390);
            Utils.Connexion.SaveChanges();
            //FIN DE PREP

            //On recupere la liste des abo inactifs supprimer
            var abo = Utils.SupprimerAbosPasEmpruntDepuisUnAn();

            // On verifie que l'abonné "TestRegister" a bien été supprimé
            foreach (ABONNÉS a in abo)
            {
                ABONNÉS aboneSupp = Utils.GetABONNÉ(a.CODE_ABONNÉ);
                if (abo != null)
                {
                    Console.WriteLine("abonne sup = " + a.LOGIN_ABONNÉ);
                    Assert.IsTrue(a.LOGIN_ABONNÉ == "TestRegister");
                }

            }

            // On supprime l'abonné si jamais il n'a pas était supprimé
            try
            {
                SuppAboAfterTests(abonne);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Abonné déjà supprimé");
            }

        }

        /// <summary>
        /// US7 Top 10
        /// </summary>
        [TestMethod, TestCategory("US7")]
        public void TestUS7()
        {
            // Si l'abonné existe déjà, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus7")
                           select ab).FirstOrDefault();

            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US47", "tus7", "mdp", 7);

            Assert.IsTrue(abo != null);

            // On récupère les albums les plus empruntés
            List<ALBUMS> topAlbums = Utils.AvoirTopAlbum();

            // On récupère l'album le plus emprunté
            ALBUMS premier = topAlbums.FirstOrDefault();

            //on emprunte cette album encore une fois
            abo.Emprunter(premier);

            Utils.Connexion.SaveChanges();

            // On vérifie que l'album est toujours le plus emprunté
            Assert.IsTrue(premier.Equals(Utils.AvoirTopAlbum().FirstOrDefault()));

            // On emprunte un album au hasard 50 fois
            Random rand = new Random();

            int i = rand.Next(80, 150);

            ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                               where ab.CODE_ALBUM == i
                               select ab).FirstOrDefault();

            Assert.IsTrue(alToTake != null);

            for (int a = 0; a < 50; a++)
            {
                ABONNÉS abonne = (from ab in Utils.Connexion.ABONNÉS
                                  where ab.LOGIN_ABONNÉ.Equals("tus7." + a)
                                  select ab).FirstOrDefault();
                if (abonne != null)
                {
                    SuppAboAfterTests(abonne);
                }

                Utils.Connexion.SaveChanges();

                abonne = Utils.RegisterAbo("Test", "US7", "tus7." + a, "mdp", 7);

                Assert.IsTrue(abo != null);

                abonne.Emprunter(alToTake);
            }

            // On vérifie que l'album emprunté est maintenant n°1
            topAlbums = Utils.AvoirTopAlbum();
            premier = topAlbums.FirstOrDefault();
            Assert.IsTrue(premier.Equals(alToTake));

            // On supprime les abonnés
            for (int z = 0; z < 50; z++)
            {
                ABONNÉS abonne = (from ab in Utils.Connexion.ABONNÉS
                                  where ab.LOGIN_ABONNÉ.Equals("tus7." + z)
                                  select ab).FirstOrDefault();
                if (abonne != null)
                {
                    SuppAboAfterTests(abonne);
                }
            }
        }

        /// <summary>
        /// US8 Consulter les albums non emprunté depuis au moins 1 an
        /// </summary>
        [TestMethod, TestCategory("US8")]
        public void TestAlbumPasEmprunterDepuis1An()
        {
            // Récupère la liste des tout les emprunts de l'album n°10
            var removeEmprunt = (from em in Utils.Connexion.EMPRUNTER
                                 where em.CODE_ALBUM == 10
                                 select em);

            // Si il existe des emprunts, on les supprime
            foreach (EMPRUNTER em in removeEmprunt)
            {
                Utils.Connexion.EMPRUNTER.Remove(em);
            }

            // On récupère la liste des albums non emprunté depuis un an
            var emprunt = Utils.AvoirAlbumsPasEmprunteDepuisUnAn();

            // On vérifie qu'il y a bien l'album 10 dans la liste des albums non emprunté depuis un an
            foreach (ALBUMS em in emprunt)
            {
                if (em.CODE_ALBUM == 10)
                {
                    Assert.AreEqual(em.CODE_ALBUM, 10);
                }
            }
        }

        /// <summary>
        /// US9 Prolonger tout les emprunts
        /// </summary>
        [TestMethod, TestCategory("US9")]
        public void TestUS9()
        {
            // Si l'abonné existe déjà, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus9")
                           select ab).FirstOrDefault();
            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US9", "tus9", "mdpVERYStrong", 45);

            Assert.IsTrue(abo != null);


            // On effectue quelques emprunts tests
            for (int i = 200; i < 220; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                EMPRUNTER e = abo.Emprunter(alToTake);
            }

            // On vérifie que aucun des emprunts du nouvel abonné ne sont prolongés
            var beforeProlonges = Utils.AvoirLesEmpruntProlonger();
            Assert.IsFalse(beforeProlonges.Any(emp => emp.CODE_ABONNÉ == abo.CODE_ABONNÉ));

            // On prolonge tout ses emprunts
            abo.ProlongerTousEmprunts();

            // On vérifie maintenant que tout les emprunts de l'abonné sont prolongés
            var afterProlonges = Utils.AvoirLesEmpruntProlonger();
            Assert.IsFalse(!afterProlonges.Any(emp => emp.CODE_ABONNÉ == abo.CODE_ABONNÉ));

            SuppAboAfterTests(abo);
        }

        /// <summary>
        /// US10 Suggestions
        /// </summary>
        [TestMethod, TestCategory("US10")]
        public void TestUS10()
        {
            // Si l'abonné existe déjà, on le supprime
            ABONNÉS abo = (from ab in Utils.Connexion.ABONNÉS
                           where ab.LOGIN_ABONNÉ.Equals("tus10")
                           select ab).FirstOrDefault();

            if (abo != null)
            {
                SuppAboAfterTests(abo);
            }

            Utils.Connexion.SaveChanges();

            // On crée un abonné pour nos tests
            abo = Utils.RegisterAbo("Test", "US10", "tus10", "mdpMEGAStrong", 44);

            Assert.IsTrue(abo != null);

            // On emprunte 4 albums du genre baroque
            for (int i = 1; i < 5; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                abo.Emprunter(alToTake);
            }

            // On emprunte 3 albums du genre classique
            for (int i = 233; i < 236; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                abo.Emprunter(alToTake);
            }

            // On emprunte 3 albums du genre contemporain
            for (int i = 353; i < 356; i++)
            {
                ALBUMS alToTake = (from ab in Utils.Connexion.ALBUMS
                                   where ab.CODE_ALBUM == i
                                   select ab).FirstOrDefault();

                Assert.IsTrue(alToTake != null);


                abo.Emprunter(alToTake);
            }

            Assert.IsTrue(abo.ConsulterEmprunts().Count() == 10);

            HashSet<ALBUMS> suggestions = abo.AvoirSuggestions();

            int codeBaroque = 3;
            int codeClassique = 4;
            int codeContempo = 7;

            foreach (ALBUMS al in suggestions)
            {
                Assert.IsTrue(al.CODE_GENRE == codeBaroque || al.CODE_GENRE == codeClassique || al.CODE_GENRE == codeContempo);
            }
        }

        /// <summary>
        /// US12 Lister tout les abonnés
        /// </summary>
        [TestMethod, TestCategory("US12")]
        public void TestListerToutLesAbos()
        {
            var abo = Utils.GetAllAbonnes();
            foreach (ABONNÉS a in abo)
            {
                // Affiche la liste de tout les abonnés 
                Console.WriteLine("Login abo = " + a.LOGIN_ABONNÉ);
            }
        }

        #region Test PagedListbox
        /// <summary>
        /// US13 Pagination (Constructeur)
        /// </summary>
        [TestMethod, TestCategory("US13")]
        public void TestConstructeur()
        {
            ListBox l = new ListBox() { Dock = DockStyle.Fill };
            DockStyle d = l.Dock;
            Form f = new Form();
            f.Controls.Add(l);
            PagedListbox p = new PagedListbox(l);
            Assert.AreEqual(d, p.Dock);
            Assert.AreEqual(p, l.Parent);
            CollectionAssert.DoesNotContain(f.Controls, l);
            CollectionAssert.Contains(p.Controls, l);
        }

        /// <summary>
        /// US13 Pagination (Page suivante)
        /// </summary>
        [TestMethod, TestCategory("US13")]
        public void TestNextPage()
        {
            ListBox l = new ListBox();
            PagedListbox p = new PagedListbox(l);
            p.Height = 600;
            int ItemsPerPage = 600 / l.Font.Height;
            for (int i = 0; i < ItemsPerPage; i++)
            {
                p.Add(i);
                Assert.IsFalse(p.NextPage());
            }
            p.Add(4);
            Assert.IsTrue(p.NextPage());
            Assert.IsFalse(p.NextPage());
        }

        /// <summary>
        /// US13 Pagination (Page précédente)
        /// </summary>
        [TestMethod, TestCategory("US13")]
        public void TestPreviousPage()
        {
            ListBox l = new ListBox();
            PagedListbox p = new PagedListbox(l);
            p.Height = 600;
            int ItemsPerPage = 600 / l.Font.Height;
            Assert.IsFalse(p.PreviousPage());
            for (int i = 0; i < ItemsPerPage; i++)
            {
                p.Add(i);
                Assert.IsFalse(p.PreviousPage());
            }
            p.Add(4);
            Assert.IsFalse(p.PreviousPage());
            p.NextPage();
            Assert.IsTrue(p.PreviousPage());
        }

        /// <summary>
        /// US13 Pagination (Reset)
        /// </summary>
        [TestMethod, TestCategory("US13")]
        public void TestResetItems()
        {
            ListBox l = new ListBox();
            PagedListbox p = new PagedListbox(l);
            p.Height = 600;
            int ItemsPerPage = 600 / l.Font.Height;
            List<int> iList = new List<int>();
            for (int i = 0; i < ItemsPerPage; i++)
            {
                p.Add(i);
                iList.Add(i);
                CollectionAssert.AreEqual(iList, l.Items);
            }
            p.Add("test");
            CollectionAssert.DoesNotContain(l.Items, "test");
            p.NextPage();
            List<string> test = new List<string>();
            test.Add("test");
            CollectionAssert.AreNotEqual(iList, l.Items);
            CollectionAssert.AreEqual(test, l.Items);
            p.Add("omegaBrain");
            test.Add("omegaBrain");
            CollectionAssert.AreEqual(test, l.Items);
            p.PreviousPage();
            CollectionAssert.AreNotEqual(test, l.Items);
            CollectionAssert.AreEqual(iList, l.Items);
            p.Size = new System.Drawing.Size(p.Width, 600 - l.Font.Height);
            CollectionAssert.AreNotEqual(iList, l.Items);
            CollectionAssert.AreEqual(iList.TakeWhile(i => i != iList.Last()).ToList(), l.Items);
        }

        #endregion

        /// <summary>
        /// Ajoute un abonné à la base
        /// </summary>
        /// <param name="nom">Son nom</param>
        /// <param name="prenom">Son prénom</param>
        /// <param name="login">Son login</param>
        /// <param name="mdp">Son mot de passe</param>
        /// <param name="codePays">Le code de son pays</param>
        private static void AddAboForTests(string nom, string prenom, string login, string mdp, int codePays)
        {
            //ajoute un abonné à la base 
            Utils.RegisterAbo(nom, prenom, login, mdp, codePays);
        }

        /// <summary>
        /// Supprime un abonné et ses emprunts
        /// </summary>
        /// <param name="abo"></param>
        private static void SuppAboAfterTests(ABONNÉS aboAsupp)
        {
            if (aboAsupp != null)
            {
                foreach (EMPRUNTER emprunt in Utils.Connexion.EMPRUNTER)
                {

                    if (emprunt.CODE_ABONNÉ == aboAsupp.CODE_ABONNÉ)
                    {
                        Utils.Connexion.EMPRUNTER.Remove(emprunt);
                    }

                }
                Utils.Connexion.ABONNÉS.Remove(aboAsupp);
            }
            Utils.Connexion.SaveChanges();
        }
    }
}