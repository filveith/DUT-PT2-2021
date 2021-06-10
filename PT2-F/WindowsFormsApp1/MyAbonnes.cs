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

        public async Task<EMPRUNTER> Emprunter(ALBUMS a)
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
                await Utils.Connexion.SaveChanges();
                return e;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("erreur : " + e);
                Utils.RefreshDatabase();
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<List<EMPRUNTER>> ProlongerTousEmprunts()
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
            await Utils.Connexion.SaveChanges();
            Console.WriteLine(i + " rallongement(s) effectué(s)");
            return emprunts;
        }

        /// <summary>
        /// Retourne un dictionnary avec la liste des emprunt et l'album correspondant
        /// </summary>
        /// <returns></returns>
        public Dictionary<EMPRUNTER, ALBUMS> ConsulterEmprunts()
        {
            Dictionary<EMPRUNTER, ALBUMS> emprunts = new Dictionary<EMPRUNTER, ALBUMS>();
            var emprunt = from alb in Utils.Connexion.ALBUMS
                          join emp in Utils.Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                          join abo in Utils.Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                          where abo.CODE_ABONNÉ == this.CODE_ABONNÉ
                          orderby emp.DATE_RETOUR_ATTENDUE ascending
                          select new { emprunt = emp, album = alb };



            foreach (var al in emprunt)
            {
                emprunts.Add(al.emprunt, al.album);
            }
            return emprunts;
        }

        public async Task<bool> ProlongerEmprunt(ALBUMS al)
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
                    await Utils.Connexion.SaveChanges();
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

            var emprunts = ConsulterEmprunts();


            int nbEmprunts = emprunts.Count();

            List<GENRES> genres = Utils.Connexion.GENRES.ToList();
            // Pour chaque emprunt :
            foreach (EMPRUNTER e in emprunts.Keys)
            {
                ALBUMS album = emprunts[e];

                GENRES genreAlbum = (from gen in genres
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

        public Dictionary<GENRES, double> GetPreferences_Opti()
        {
            Dictionary<GENRES, double> preferences = new Dictionary<GENRES, double>();
            var emprunts = (from emp in Utils.Connexion.EMPRUNTER
                            join gen in Utils.Connexion.GENRES on emp.ALBUMS.CODE_GENRE equals gen.CODE_GENRE
                            where emp.CODE_ABONNÉ == this.CODE_ABONNÉ
                            select new { emprunt = emp, genre = gen });
            int Count = emprunts.Count();
            var GroupedEmprunts = emprunts.GroupBy(x => x.genre);
            foreach (var e in GroupedEmprunts)
            {
                int nEmprunts = e.Count();
                preferences.Add(e.Key, nEmprunts * 100f / Count);
            }
            return preferences;
        }

        public HashSet<ALBUMS> AvoirSuggestions_Opti()
        {
            var pref = GetPreferences_Opti();
            int i = 0;
            HashSet<ALBUMS> suggestions = new HashSet<ALBUMS>();
            Random r = new Random();
            foreach (var v in pref)
            {
                if (i < 10)
                {
                    List<ALBUMS> AlbumsOfGenre = v.Key.ALBUMS.ToList();
                    int numAlbums = Round(v.Value / 10f);
                    for (int n = 0; n < numAlbums && i < 10; i++)
                    {
                        int ind = r.Next(AlbumsOfGenre.Count);
                        suggestions.Add(AlbumsOfGenre[ind]);
                        AlbumsOfGenre.RemoveAt(ind);
                    }
                }
            }

            return suggestions;
        }

        public int Round(double n)
        {
            if (n >= 0)
            {
                return (int)(n + 0.5);
            }
            return (int)(n - 0.5);
        }

    }
}
