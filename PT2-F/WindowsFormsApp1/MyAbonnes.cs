using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class ABONNÉS
    {
        /// <summary>
        /// Affiche des informations sur l'abonné
        /// </summary>
        /// <returns>Les informations sous forme de string</returns>
        public override string ToString()
        {
            return this.NOM_ABONNÉ.Trim() + " " + this.PRÉNOM_ABONNÉ.Trim();
        }

        /// <summary>
        /// Crée un nouvel emprunt pour cet abonné et l'album précisé
        /// </summary>
        /// <param name="album">L'album</param>
        /// <returns></returns>
        public async Task<EMPRUNTER> Emprunter(ALBUMS album)
        {
            try
            {
                int delai = (from al in Utils.Connexion.ALBUMS
                             join genre in Utils.Connexion.GENRES on al.CODE_GENRE equals genre.CODE_GENRE
                             where al.CODE_ALBUM == album.CODE_ALBUM
                             select genre.DÉLAI).First();
                DateTime retour = DateTime.Now.AddDays(delai);
                EMPRUNTER e = new EMPRUNTER { CODE_ABONNÉ = this.CODE_ABONNÉ, CODE_ALBUM = album.CODE_ALBUM, DATE_EMPRUNT = DateTime.Now, DATE_RETOUR_ATTENDUE = retour };
                Utils.Connexion.EMPRUNTER.Add(e);
                Utils.Connexion.SaveChanges();
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

        /// <summary>
        /// Prolonge tout les emprunts de l'abonné
        /// </summary>
        /// <returns></returns>
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
            Utils.Connexion.SaveChanges();
            Console.WriteLine(i + " rallongement(s) effectué(s)");
            return emprunts;
        }

        /// <summary>
        /// Retourne un dictionnaire de tout les albums empruntés par l'abonné
        /// </summary>
        /// <returns>Le dictionnaire des emprunts</returns>
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

        /// <summary>
        /// Prolonge l'emprunt d'un album
        /// </summary>
        /// <param name="album">L'album</param>
        /// <returns></returns>
        public async Task<bool> ProlongerEmprunt(ALBUMS album)
        {
            EMPRUNTER emprunt = (from emp in Utils.Connexion.EMPRUNTER
                                 where emp.CODE_ABONNÉ == this.CODE_ABONNÉ && emp.CODE_ALBUM == album.CODE_ALBUM
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
        /// Calcule le pourcentage de préférence de chaque genre de cet abonné
        /// </summary>
        /// <returns>Un dictionnaire des préférences</returns>
        private Dictionary<GENRES, double> GetPreferences()
        {
            // On crée d'abord un dictionnaire qui associe une string (un genre de musique)
            // à un int (combien d'album de ce genre ont été emprunté par l'abonné)
            Dictionary<GENRES, double> preferences = new Dictionary<GENRES, double>();
            var emprunts = (from emp in Utils.Connexion.EMPRUNTER
                            join gen in Utils.Connexion.GENRES on emp.ALBUMS.CODE_GENRE equals gen.CODE_GENRE
                            where emp.CODE_ABONNÉ == this.CODE_ABONNÉ
                            select new { emprunt = emp, genre = gen });
            int Count = emprunts.Count();
            var GroupedEmprunts = emprunts.GroupBy(x => x.genre);

            // Pour chaque emprunt :
            foreach (var e in GroupedEmprunts)
            {
                int nEmprunts = e.Count();
                preferences.Add(e.Key, nEmprunts * 100f / Count);
            }

            return preferences;
        }

        /// <summary>
        /// Renvoie 10 suggestions
        /// </summary>
        /// <returns>Une liste d'albums</returns>
        public HashSet<ALBUMS> AvoirSuggestions()
        {

            // On récupère les préférences de l'abonné
            var pref = GetPreferences();
            int i = 0;
            HashSet<ALBUMS> suggestions = new HashSet<ALBUMS>();
            Random r = new Random();

            // Pour chaque genre parmi les préférences de l'abonné :
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

        public void ChangePassword(string newPass)
        {
            this.PASSWORD_ABONNÉ = Utils.ComputeSha256Hash(newPass);
            Utils.Connexion.SaveChanges();
        }

    }
}
