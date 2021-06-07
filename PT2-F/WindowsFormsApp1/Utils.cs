using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Utils
    {
        public static MusiquePT2_FEntities Connexion = new MusiquePT2_FEntities();
        public static bool RegisterAbo(string nom, string prenom, string login, string mdp, int codePays)
        {
            try
            {
                // on crée un nouveau Abonné
                ABONNÉS a = new ABONNÉS();
                if (codePays > 0)
                {
                    a.CODE_PAYS = codePays;
                }
                a.NOM_ABONNÉ = nom.Substring(0, Math.Min(nom.Length, 32));
                a.PRÉNOM_ABONNÉ = prenom.Substring(0, Math.Min(prenom.Length, 32));
                a.LOGIN_ABONNÉ = login.Substring(0, Math.Min(login.Length, 32));
                a.PASSWORD_ABONNÉ = mdp.Substring(0, Math.Min(mdp.Length, 32));
                a.creationDate = DateTime.Now;


                // ajout du nouveau Abonné
                Connexion.ABONNÉS.Add(a);
                Connexion.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        /// <summary>
        /// Retourne une liste des abonnes avec des emrpunts en retard de plus de 10jours
        /// </summary>
        /// <returns></returns>
        public static List<ABONNÉS> AvoirAbonneAvecEmpruntRetardDe10Jours()
        {
            List<ABONNÉS> result = new List<ABONNÉS>();
            var emprunt = from emp in Connexion.EMPRUNTER
                          where emp.DATE_RETOUR == null && DbFunctions.DiffDays(emp.DATE_RETOUR_ATTENDUE, DateTime.Now) > 10
                          select emp;

            foreach (EMPRUNTER e in emprunt)
            {
                ABONNÉS abonne = GetABONNÉ(e.CODE_ABONNÉ);
                result.Add(abonne);

                ALBUMS album = GetALBUM(e.CODE_ALBUM);

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
            foreach (ABONNÉS a in abos)
            {
                var emprunts = (from e in Connexion.EMPRUNTER
                                where e.CODE_ABONNÉ == a.CODE_ABONNÉ
                                select e);
                Connexion.EMPRUNTER.RemoveRange(emprunts);
                Connexion.ABONNÉS.Remove(a);

            }
            Connexion.SaveChanges();
            return abos;
        }

        public static List<EMPRUNTER> ProlongerTousEmprunts(int codeAbonne)
        {
            int i = 0;
            var emprunts = (from emp in Connexion.EMPRUNTER
                            where emp.CODE_ABONNÉ == codeAbonne && emp.nbRallongements == 0
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

        /// <summary>
        /// Retourne un dictionnary avec la liste des emprunt et la nom de l'abonne correspondant
        /// </summary>
        /// <param name="codeabo"></param>
        /// <returns></returns>
        public static Dictionary<EMPRUNTER, ABONNÉS> ConsulterEmprunts(int codeabo)
        {
            Dictionary<EMPRUNTER, ABONNÉS> emprunts = new Dictionary<EMPRUNTER, ABONNÉS>();
            var abonne = GetABONNÉ(codeabo);
            var emprunt = (from alb in Connexion.ALBUMS
                           join emp in Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                           join abo in Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                           where abo.CODE_ABONNÉ == codeabo
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

        public static bool ProlongerEmprunt(int codeAbonne, int codeAlbumSelected)
        {
            EMPRUNTER emprunt = (from emp in Connexion.EMPRUNTER
                                 where emp.CODE_ABONNÉ == codeAbonne && emp.CODE_ALBUM == codeAlbumSelected
                                 select emp).FirstOrDefault();
            if (emprunt != null)
            {
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
            return false;
        }

        /// <summary>
        /// Retourne les genres avec pourcentage de prefs de l'abo
        /// </summary>
        /// <param name="codeAbonne"></param>
        /// <returns></returns>
        private static Dictionary<string, double> GetPreferences(int codeAbonne)
        {
            // On crée d'abord un dictionnaire qui associe une string (un genre de musique)
            // à un int (combien d'album de ce genre on été emprunté par l'abonné)
            Dictionary<string, int> allGenre = new Dictionary<string, int>();

            var emprunts = from emp in Connexion.EMPRUNTER
                           where emp.CODE_ABONNÉ == codeAbonne
                           select emp;

            int nbEmprunts = emprunts.Count();

            // Pour chaque emprunt :
            foreach (EMPRUNTER e in emprunts)
            {
                ALBUMS album = GetALBUM(e.CODE_ALBUM);

                GENRES genreAlbum = (from gen in Connexion.GENRES
                                     where gen.CODE_GENRE == album.CODE_GENRE
                                     select gen).FirstOrDefault();

                string nomGenre = genreAlbum.LIBELLÉ_GENRE;


                if (allGenre.Count() > 0)
                {
                    // Si ce genre d'album a déjà été rencontré, on incremente sa valeur
                    if (allGenre.ContainsKey(nomGenre))
                    {
                        allGenre[nomGenre]++;
                    }
                    // Sinon, on l'ajoute à la liste avec une valeur initiale de 1
                    else
                    {
                        allGenre.Add(nomGenre, 1);
                    }

                }
                // Si il s'agit du premier genre de la liste
                else
                {
                    allGenre.Add(nomGenre, 1);
                }


            }

            // Les preferences seront conservées dans un dictionnaire,
            // qui associera une string (le genre) à un double (le pourcentage)
            Dictionary<string, double> preferencesByGenre = new Dictionary<string, double>();

            // On calcule le pourcentage de préférence de ce genre pour cet utilisateur
            // (nb d'album empruntés de ce genre / nb d'emprunts total)
            foreach (KeyValuePair<string, int> values in allGenre)
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
        public static HashSet<ALBUMS> AvoirSuggestions(int codeAbonne)
        {
            // On recupère les preferences de l'abonné
            Dictionary<string, double> preferences = GetPreferences(codeAbonne);

            Random rdm = new Random();

            HashSet<ALBUMS> suggestionsNOTFINAL = new HashSet<ALBUMS>();

            // Pour chaque genre parmi les préférences de l'abonné :
            foreach (string genre in preferences.Keys)
            {
                // On récupère le code du genre et le pourcentage associé
                int codeGenre = (from g in Connexion.GENRES
                                 where g.LIBELLÉ_GENRE == genre
                                 select g.CODE_GENRE).FirstOrDefault();

                double percentage = preferences[genre];

                // Le pourcentage détermine combien de fois des albums de ce genre auront tendance à être choisis pour la sélection finale
                int nbToTake = (int)percentage;
                for (int i = 0; i < nbToTake; i++)
                {
                    // On choisit un album au hasard et, si il est du bon genre, on le rajoute à la sélection NON FINALE 
                    ALBUMS currentSugg = Connexion.ALBUMS.OrderBy(r => Guid.NewGuid()).Skip(rdm.Next(1, 10)).FirstOrDefault();
                    if (currentSugg.CODE_GENRE == codeGenre)
                    {
                        suggestionsNOTFINAL.Add(currentSugg);
                    }
                }
            }

            // Les suggestions finales sont conservées dans un HashSet pour éviter les doublons
            HashSet<ALBUMS> suggestionsFinal = new HashSet<ALBUMS>();

            ALBUMS[] suggArray = suggestionsNOTFINAL.ToArray();
            if (suggArray.Length > 0)
            {
                // On récupère 10 suggestions, qui composeront la suggestion finale
                for (int i = 0; i < 10; i++)
                {
                    ALBUMS sugg = suggArray[rdm.Next(0, suggArray.Length)];
                    suggestionsFinal.Add(sugg);
                    List<ALBUMS> provisory = new List<ALBUMS>(suggArray);
                    provisory.Remove(sugg);
                    suggArray = provisory.ToArray();
                }
            }
            return suggestionsFinal;
        }

        public static List<PAYS> AvoirListeDesPays()
        {
            List<PAYS> listPays = new List<PAYS>();
            var pays = from p in Connexion.PAYS
                       select p;

            foreach (PAYS nom in pays)
            {
                listPays.Add(nom);
            }
            return listPays;
        }

        public static void RefreshDatabase()
        {
            Connexion.Dispose();
            Connexion = new MusiquePT2_FEntities();
        }

        public static ABONNÉS GetABONNÉ(int codeAbonne)
        {
            return (from a in Connexion.ABONNÉS
                    where a.CODE_ABONNÉ == codeAbonne
                    select a).FirstOrDefault();
        }

        public static ALBUMS GetALBUM(int codeAlbum)
        {
            return (from al in Connexion.ALBUMS
                    where al.CODE_ALBUM == codeAlbum
                    select al).FirstOrDefault();
        }
    }
}
