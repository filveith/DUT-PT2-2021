using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Utils
    {
        private static MusiquePT2_FEntities Connexion = new MusiquePT2_FEntities();

        public static List<ABONNÉS> AvoirAbonneAvecEmpruntRetardDe10Jours()
        {
            List<ABONNÉS> result = new List<ABONNÉS>();
            var emprunt = from emp in Connexion.EMPRUNTER
                          where emp.DATE_RETOUR == null && DbFunctions.DiffDays(emp.DATE_RETOUR_ATTENDUE, DateTime.Now) > 10
                          select emp;

            foreach (EMPRUNTER e in emprunt)
            {
                ABONNÉS abonne = (from abo in Connexion.ABONNÉS
                                  where abo.CODE_ABONNÉ == e.CODE_ABONNÉ
                                  select abo).First();
                result.Add(abonne);

                ALBUMS album = (from alb in Connexion.ALBUMS
                                where alb.CODE_ALBUM == e.CODE_ALBUM
                                select alb).First();

                Console.WriteLine(abonne.PRÉNOM_ABONNÉ + " " + abonne.NOM_ABONNÉ + " " + album.TITRE_ALBUM);
            }
            return result;
        }

        public static List<EMPRUNTER> AvoirLesEmpruntProlonger()
        {
            List<EMPRUNTER> result = (from emp in Connexion.EMPRUNTER
                                      join abo in Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                                      join alb in Connexion.ALBUMS on emp.CODE_ALBUM equals alb.CODE_ALBUM
                                      where emp.nbRallongements > 0
                                      select emp).ToList();

                
            return result;
        }
        public static List<ALBUMS> AvoirAlbumsPasEmprunteDepuisUnAn()
        {                
            List<ALBUMS> liste = (from a in Connexion.ALBUMS
                                  join e in Connexion.EMPRUNTER
                                  on a.CODE_ALBUM equals e.CODE_ALBUM into empDept
                                  from ed in empDept.DefaultIfEmpty()
                                  where empDept.Count() == 0 || DbFunctions.DiffDays(ed.DATE_EMPRUNT, DateTime.Now) > 365
                                  select a).ToList().Distinct().ToList();

            return liste;
        }

        private static List<ABONNÉS> AvoirAbosPasEmprunteDepuisUnAn()
        {
            var abosPasEmprunt = (from a in Connexion.ABONNÉS
                                  join e in Connexion.EMPRUNTER
                                  on a.CODE_ABONNÉ equals e.CODE_ABONNÉ into empDept
                                  from ed in empDept.DefaultIfEmpty()
                                  where empDept.Count() == 0 && DbFunctions.DiffDays(a.creationDate, DateTime.Now) > 365
                                  select a);
            var abosDejaEmprunt = (from a in Connexion.ABONNÉS
                                   join e in Connexion.EMPRUNTER
                                   on a.CODE_ABONNÉ equals e.CODE_ABONNÉ
                                   where DbFunctions.DiffDays(e.DATE_EMPRUNT, DateTime.Now) > 365
                                   select a).Union(abosPasEmprunt).ToList().Distinct();

            var abos = abosDejaEmprunt.Union(abosPasEmprunt).ToList();

            return abos;
        }

        public static List<ABONNÉS> SupprimerAbosPasEmpruntDepuisUnAn()
        {
            List<ABONNÉS> abos = AvoirAbosPasEmprunteDepuisUnAn();
            Connexion.ABONNÉS.RemoveRange(abos);
            Connexion.SaveChanges();
            return abos;
        }

        public static List<EMPRUNTER> prolongerTousEmprunts(int codeAbonne)
        {
            int i = 0;
            var emprunts = (from emp in Connexion.EMPRUNTER
                           where emp.CODE_ABONNÉ == codeAbonne
                           where emp.nbRallongements == 0
                           select emp).ToList();


            foreach (EMPRUNTER e in emprunts)
            {
                i++;
                e.DATE_RETOUR_ATTENDUE = e.DATE_RETOUR_ATTENDUE.AddMonths(1);
                e.nbRallongements = 1;
            }
            Connexion.SaveChanges();
            Console.WriteLine(i + " rallongement(s) effectué(s)");
            return emprunts;
        }

        public static Dictionary<EMPRUNTER, ABONNÉS> ConsulterEmprunts(string login)
        {
            Dictionary<EMPRUNTER, ABONNÉS> emprunts = new Dictionary<EMPRUNTER, ABONNÉS>();
            var abonne = (from a in Connexion.ABONNÉS
                          where a.LOGIN_ABONNÉ == login
                          select a).First();
            var emprunt = (from alb in Connexion.ALBUMS
                           join emp in Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                           join abo in Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                           where abo.LOGIN_ABONNÉ == login
                           orderby emp.DATE_RETOUR_ATTENDUE ascending
                           select new { emprunt = emp, abonne = abo }).ToList();



            foreach (var al in emprunt)
            {
                emprunts.Add(al.emprunt, al.abonne);
                //Console.WriteLine(em) ;
            }
            return emprunts;
        }

        public static List<ALBUMS> AvoirTopAlbum()
        {
            var nbEmprunt = (from emp in Connexion.EMPRUNTER
                             select emp.CODE_ALBUM).Count();

            var top = (from alb in Connexion.ALBUMS
                       join emp in Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                       group alb by alb.CODE_ALBUM into groupés
                       orderby groupés.Count() descending
                       select groupés).Take(10);

            var liste = top.SelectMany(group => group).ToList().Distinct().ToList();
            
            return liste;
        }

        public static bool prolongerEmprunt(int codeAbonne, int codeAlbumSelected)
        {
            EMPRUNTER emprunt = (from emp in Connexion.EMPRUNTER
                                 where emp.CODE_ABONNÉ == codeAbonne && emp.CODE_ALBUM == codeAlbumSelected
                                 select emp).First();

            if (emprunt.nbRallongements != 1)
            {
                emprunt.DATE_RETOUR_ATTENDUE = emprunt.DATE_RETOUR_ATTENDUE.AddMonths(1);
                emprunt.nbRallongements = 1;
                Console.WriteLine("Rallongement effectué");
                return true;
            }
            else
            {
                Console.WriteLine("Vous avez déjà rallonger cet emprunt :/");
                return false;
            }
        }

        /// <summary>
        /// Retourne les genres avec pourcentage de prefs de l'abo
        /// </summary>
        /// <param name="codeAbonne"></param>
        /// <returns></returns>
        private static Dictionary<string, double> getPreferences(int codeAbonne)
        {
            Dictionary<string, int> allGenre = new Dictionary<string, int>();
            var emprunts = from emp in Connexion.EMPRUNTER
                           where emp.CODE_ABONNÉ == codeAbonne
                           select emp;
            
            int nbEmprunts = emprunts.Count();

            foreach(EMPRUNTER e in emprunts)
            {
                ALBUMS album = (from al in Connexion.ALBUMS
                                where al.CODE_ALBUM == e.CODE_ALBUM
                                select al).First();

                GENRES genreAlbum = (from gen in Connexion.GENRES
                                     where gen.CODE_GENRE == album.CODE_GENRE
                                     select gen).First();

                string nomGenre = genreAlbum.LIBELLÉ_GENRE;

                List<string> keys;
                if (allGenre.Count() > 0)
                {

                    keys = new List<string>(allGenre.Keys);
                    if (allGenre.ContainsKey(nomGenre))
                    {
                        allGenre[nomGenre]++;
                    }
                    else
                    {
                        allGenre.Add(nomGenre, 1);
                    }
                    
                } else
                {
                    allGenre.Add(nomGenre, 1);
                }

                
            }

            Dictionary<string, double> preferencesByGenre = new Dictionary<string, double>();

            foreach(KeyValuePair<string, int> values in allGenre)
            {
                int v = values.Value;
                double result = (double)v / nbEmprunts * 100;
                preferencesByGenre.Add(values.Key, result);
            }

            return preferencesByGenre;
        }

        /// <summary>
        /// Renvoie 10 suggestions
        /// </summary>
        /// <param name="codeAbonne"></param>
        /// <returns></returns>
        public static HashSet<ALBUMS> suggest(int codeAbonne) 
        {
            Dictionary<string, double> preferences = getPreferences(codeAbonne);

            Random rdm = new Random();

            HashSet<ALBUMS> suggestionsNOTFINAL = new HashSet<ALBUMS>();

            foreach(string genre in preferences.Keys)
            {
                int codeGenre = (from g in Connexion.GENRES
                                 where g.LIBELLÉ_GENRE == genre
                                 select g.CODE_GENRE).First();

                double percentage = preferences[genre];

                int nbToTake = (int)percentage;

                for (int i = 0; i < nbToTake; i++)
                {
                    ALBUMS currentSugg = Connexion.ALBUMS.OrderBy(r => Guid.NewGuid()).Skip(rdm.Next(1, 10)).Take(1).First();

                    if (currentSugg.CODE_GENRE == codeGenre)
                    {
                        suggestionsNOTFINAL.Add(currentSugg);
                    }
                }
            }
            ALBUMS[] suggArray = suggestionsNOTFINAL.ToArray();

            HashSet<ALBUMS> suggestionsFinal = new HashSet<ALBUMS>();

            for (int i = 0; i < 10; i++)
            {
                ALBUMS sugg = suggArray[rdm.Next(0, suggArray.Length)];
                suggestionsFinal.Add(sugg);
                List<ALBUMS> provisory = new List<ALBUMS>(suggArray);
                provisory.Remove(sugg);
                suggArray = provisory.ToArray();
            }

            return suggestionsFinal;



        }

        /// <summary>
        /// Retourne les genres avec pourcentage de prefs de l'abo
        /// </summary>
        /// <param name="codeAbonne"></param>
        /// <returns></returns>
        private static Dictionary<string, double> getPreferences(int codeAbonne)
        {
            Dictionary<string, int> allGenre = new Dictionary<string, int>();
            var emprunts = from emp in Connexion.EMPRUNTER
                           where emp.CODE_ABONNÉ == codeAbonne
                           select emp;
            
            int nbEmprunts = emprunts.Count();

            foreach(EMPRUNTER e in emprunts)
            {
                ALBUMS album = (from al in Connexion.ALBUMS
                                where al.CODE_ALBUM == e.CODE_ALBUM
                                select al).First();

                GENRES genreAlbum = (from gen in Connexion.GENRES
                                     where gen.CODE_GENRE == album.CODE_GENRE
                                     select gen).First();

                string nomGenre = genreAlbum.LIBELLÉ_GENRE;

                List<string> keys;
                if (allGenre.Count() > 0)
                {

                    keys = new List<string>(allGenre.Keys);
                    if (allGenre.ContainsKey(nomGenre))
                    {
                        allGenre[nomGenre]++;
                    }
                    else
                    {
                        allGenre.Add(nomGenre, 1);
                    }
                    
                } else
                {
                    allGenre.Add(nomGenre, 1);
                }

                
            }

            Dictionary<string, double> preferencesByGenre = new Dictionary<string, double>();

            foreach(KeyValuePair<string, int> values in allGenre)
            {
                int v = values.Value;
                double result = (double)v / nbEmprunts * 100;
                preferencesByGenre.Add(values.Key, result);
            }

            return preferencesByGenre;
        }

        /// <summary>
        /// Renvoie 10 suggestions
        /// </summary>
        /// <param name="codeAbonne"></param>
        /// <returns></returns>
        public static HashSet<ALBUMS> suggest(int codeAbonne) 
        {
            Dictionary<string, double> preferences = getPreferences(codeAbonne);

            Random rdm = new Random();

            HashSet<ALBUMS> suggestionsNOTFINAL = new HashSet<ALBUMS>();

            foreach(string genre in preferences.Keys)
            {
                int codeGenre = (from g in Connexion.GENRES
                                 where g.LIBELLÉ_GENRE == genre
                                 select g.CODE_GENRE).First();

                double percentage = preferences[genre];

                int nbToTake = (int)percentage;

                for (int i = 0; i < nbToTake; i++)
                {
                    ALBUMS currentSugg = Connexion.ALBUMS.OrderBy(r => Guid.NewGuid()).Skip(rdm.Next(1, 10)).Take(1).First();

                    if (currentSugg.CODE_GENRE == codeGenre)
                    {
                        suggestionsNOTFINAL.Add(currentSugg);
                    }
                }
            }
            ALBUMS[] suggArray = suggestionsNOTFINAL.ToArray();

            HashSet<ALBUMS> suggestionsFinal = new HashSet<ALBUMS>();

            for (int i = 0; i < 10; i++)
            {
                ALBUMS sugg = suggArray[rdm.Next(0, suggArray.Length)];
                suggestionsFinal.Add(sugg);
                List<ALBUMS> provisory = new List<ALBUMS>(suggArray);
                provisory.Remove(sugg);
                suggArray = provisory.ToArray();
            }

            return suggestionsFinal;



        }
    }
}
