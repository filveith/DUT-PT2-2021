using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class ABONNÉS
    {
        public override string ToString()
        {
            return this.NOM_ABONNÉ.Trim() + " " + this.PRÉNOM_ABONNÉ.Trim();
        }

        public EMPRUNTER Emprunter(ALBUMS a)
        {
            try
            {
                int delai = (from al in Utils.Connexion.ALBUMS
                             join genre in Utils.Connexion.GENRES on al.CODE_GENRE equals genre.CODE_GENRE
                             where al.CODE_ALBUM == a.CODE_ALBUM
                             select genre.DÉLAI).First();
                DateTime retour = DateTime.Now.AddDays(delai);
                EMPRUNTER e = new EMPRUNTER { CODE_ABONNÉ = this.CODE_ABONNÉ, CODE_ALBUM = a.CODE_ALBUM, DATE_EMPRUNT = DateTime.Now, DATE_RETOUR_ATTENDUE = retour };
                Utils.Connexion.EMPRUNTER.Add(e);
                Utils.Connexion.SaveChanges();
                return e;
            }
            catch (DbUpdateException)
            {
                Utils.RefreshDatabase();
                return null;
            }
        }

        public List<EMPRUNTER> ProlongerTousEmprunts()
        {
            int i = 0;
            var emprunts = (from emp in Utils.Connexion.EMPRUNTER
                            where emp.CODE_ABONNÉ == this.CODE_ABONNÉ && emp.nbRallongements == 0
                            select emp).ToList();


            foreach (EMPRUNTER e in emprunts)
            {
                i++;
                e.DATE_RETOUR_ATTENDUE = e.DATE_RETOUR_ATTENDUE.AddMonths(1);
                e.nbRallongements = 1;
            }
            Utils.Connexion.SaveChanges();
            Console.WriteLine(i + " rallongement(s) effectué(s)");
            return emprunts;
        }

        /// <summary>
        /// Retourne un dictionnary avec la liste des emprunt et la nom de l'abonne correspondant
        /// </summary>
        /// <param name="codeabo"></param>
        /// <returns></returns>
        public Dictionary<EMPRUNTER, ABONNÉS> ConsulterEmprunts()
        {
            Dictionary<EMPRUNTER, ABONNÉS> emprunts = new Dictionary<EMPRUNTER, ABONNÉS>();
            var emprunt = (from alb in Utils.Connexion.ALBUMS
                           join emp in Utils.Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                           join abo in Utils.Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                           where abo.CODE_ABONNÉ == this.CODE_ABONNÉ
                           orderby emp.DATE_RETOUR_ATTENDUE ascending
                           select new { emprunt = emp, abonne = this }).ToList();



            foreach (var al in emprunt)
            {
                emprunts.Add(al.emprunt, al.abonne);
                //Console.WriteLine(em) ;
            }
            return emprunts;
        }

        public bool ProlongerEmprunt(ALBUMS al)
        {
            EMPRUNTER emprunt = (from emp in Utils.Connexion.EMPRUNTER
                                 where emp.CODE_ABONNÉ == this.CODE_ABONNÉ && emp.CODE_ALBUM == al.CODE_ALBUM
                                 select emp).FirstOrDefault();
            if (emprunt != null)
            {
                if (emprunt.nbRallongements != 1)
                {
                    emprunt.DATE_RETOUR_ATTENDUE = emprunt.DATE_RETOUR_ATTENDUE.AddMonths(1);
                    emprunt.nbRallongements = 1;
                    Utils.Connexion.SaveChanges();
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
        private Dictionary<string, double> GetPreferences()
        {
            // On crée d'abord un dictionnaire qui associe une string (un genre de musique)
            // à un int (combien d'album de ce genre on été emprunté par l'abonné)
            Dictionary<string, int> allGenre = new Dictionary<string, int>();

            var emprunts = from emp in Utils.Connexion.EMPRUNTER
                           where emp.CODE_ABONNÉ == this.CODE_ABONNÉ
                           select emp;

            int nbEmprunts = emprunts.Count();

            // Pour chaque emprunt :
            foreach (EMPRUNTER e in emprunts)
            {
                ALBUMS album = Utils.GetALBUM(e.CODE_ALBUM);

                GENRES genreAlbum = (from gen in Utils.Connexion.GENRES
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
        public HashSet<ALBUMS> AvoirSuggestions()
        {
            // On recupère les preferences de l'abonné
            Dictionary<string, double> preferences = GetPreferences();

            Random rdm = new Random();

            HashSet<ALBUMS> suggestionsNOTFINAL = new HashSet<ALBUMS>();

            // Pour chaque genre parmi les préférences de l'abonné :
            foreach (string genre in preferences.Keys)
            {
                // On récupère le code du genre et le pourcentage associé
                int codeGenre = (from g in Utils.Connexion.GENRES
                                 where g.LIBELLÉ_GENRE == genre
                                 select g.CODE_GENRE).FirstOrDefault();

                double percentage = preferences[genre];

                // Le pourcentage détermine combien de fois des albums de ce genre auront tendance à être choisis pour la sélection finale
                int nbToTake = (int)percentage;
                for (int i = 0; i < nbToTake; i++)
                {
                    // On choisit un album au hasard et, si il est du bon genre, on le rajoute à la sélection NON FINALE 
                    ALBUMS currentSugg = Utils.Connexion.ALBUMS.OrderBy(r => Guid.NewGuid()).Skip(rdm.Next(1, 10)).FirstOrDefault();
                    if (currentSugg.CODE_GENRE == codeGenre)
                    {
                        suggestionsNOTFINAL.Add(currentSugg);
                    }
                }
            }

            // Les suggestions finales sont conservées dans un HashSet pour éviter les doublons
            HashSet<ALBUMS> suggestionsFinal = new HashSet<ALBUMS>();

            ALBUMS[] suggArray = suggestionsNOTFINAL.ToArray();

            int stop = 10;
            if (suggArray.Length < 10)
            {
                stop = suggArray.Length;
            }

            // On récupère 10 suggestions maximum, qui composeront la suggestion finale
            for (int i = 0; i < stop; i++)
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
