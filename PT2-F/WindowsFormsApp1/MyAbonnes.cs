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
            return "\"" + this.NOM_ABONNÉ.Trim() + " " + this.PRÉNOM_ABONNÉ.Trim() + "\"" + " date de création : " + creationDate;
        }

        /// <summary>
        /// Crée un nouvel emprunt pour cet abonné et l'album précisé
        /// </summary>
        /// <param name="album">L'album</param>
        /// <returns></return>
        public EMPRUNTER Emprunter(ALBUMS a)
        {
            try
            {
                int delai = a.GENRES.DÉLAI;
                DateTime retour = DateTime.Now.AddDays(delai);
                EMPRUNTER e = new EMPRUNTER { CODE_ABONNÉ = this.CODE_ABONNÉ, CODE_ALBUM = a.CODE_ALBUM, DATE_EMPRUNT = DateTime.Now, DATE_RETOUR_ATTENDUE = retour };
                Utils.Connexion.EMPRUNTER.Add(e);
                Utils.Connexion.SaveChanges();
                return e;
            }
            catch (DbUpdateException)
            {
                Utils.RefreshDatabase();
                EMPRUNTER e = EMPRUNTER.FirstOrDefault(emp => emp.ALBUMS == a); ;
                if (e.DATE_RETOUR != null)
                {
                    e.DATE_EMPRUNT = DateTime.Now;
                    e.DATE_RETOUR_ATTENDUE = DateTime.Now.AddDays(a.GENRES.DÉLAI);
                    Utils.Connexion.SaveChanges();
                    return e;
                }
                Utils.RefreshDatabase();
                return null;

            }
        }

        /// <summary>
        /// Permet de rendre un album
        /// </summary>
        /// <param name="album">L'album</param>
        public bool Rendre(ALBUMS album)
        {
            EMPRUNTER emprunt = EMPRUNTER.FirstOrDefault(emp => emp.ALBUMS == album);

            if (emprunt != null)
            {
                emprunt.DATE_RETOUR = DateTime.Now;
                Utils.Connexion.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Prolonge tout les emprunts de l'abonné
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EMPRUNTER> ProlongerTousEmprunts()
        {
            int i = 0;
            var emprunts = EMPRUNTER.Where(emp => emp.nbRallongements == 0 && emp.DATE_RETOUR == null);

            foreach (EMPRUNTER e in emprunts)
            {
                i++;
                e.DATE_RETOUR_ATTENDUE = e.DATE_RETOUR_ATTENDUE.AddMonths(1);
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
            var emprunt = EMPRUNTER.Where(emp => emp.DATE_RETOUR == null).OrderByDescending(emp => emp.DATE_EMPRUNT);
            foreach (var al in emprunt)
            {
                emprunts.Add(al, al.ALBUMS);
            }
            return emprunts;
        }
        /// <summary>
        /// Retourne un dictionnaire de tout les genres des albums empruntés par l'abonné
        /// </summary>
        /// <returns>Le dictionnaire des emprunts</returns>
        public Dictionary<ALBUMS, GENRES> ConsulterGenresEmprunts()
        {
            Dictionary<ALBUMS, GENRES> emprunts = new Dictionary<ALBUMS, GENRES>();
            var emprunt = ConsulterEmprunts();
            foreach (var al in emprunt)
            {
                emprunts.Add(al.Value, al.Value.GENRES);
            }
            return emprunts;
        }

        /// <summary>
        /// Prolonge l'emprunt d'un album
        /// </summary>
        /// <param name="album">L'album</param>
        /// <returns></returns>
        public EMPRUNTER ProlongerEmprunt(ALBUMS al)
        {
            EMPRUNTER emprunt = EMPRUNTER.FirstOrDefault(emp => emp.ALBUMS == al);
            if (emprunt != null)
            {
                if (emprunt.nbRallongements == 0)
                {
                    emprunt.DATE_RETOUR_ATTENDUE = emprunt.DATE_RETOUR_ATTENDUE.AddMonths(1);
                    Utils.Connexion.SaveChanges();
                    Console.WriteLine("Rallongement effectué");
                    return emprunt;
                }
                else
                {
                    Console.WriteLine("Vous avez déjà rallonger cet emprunt :/");
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Calcule le pourcentage de préférence de chaque genre de cet abonné
        /// </summary>
        /// <returns>Un dictionnaire des préférences</returns>
        public Dictionary<GENRES, double> GetPreferences()
        {
            // On crée d'abord un dictionnaire qui associe une string (un genre de musique)
            // à un int (combien d'album de ce genre ont été emprunté par l'abonné)
            Dictionary<GENRES, double> preferences = new Dictionary<GENRES, double>();
            var emprunts = EMPRUNTER;
            int Count = emprunts.Count();
            var GroupedEmprunts = emprunts.GroupBy(x => x.ALBUMS.GENRES);

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
                    int cpt = 0;
                    for (int n = 0; n < numAlbums && i < 10 && cpt < AlbumsOfGenre.Count; i++)
                    {
                        int ind = r.Next(AlbumsOfGenre.Count);
                        ALBUMS al = AlbumsOfGenre[ind];
                        ICollection<EMPRUNTER> emprunts = al.EMPRUNTER;
                        if(emprunts.Count == 0 || emprunts.All(emp => emp.DATE_RETOUR != null))
                        {
                            suggestions.Add(AlbumsOfGenre[ind]);
                            AlbumsOfGenre.RemoveAt(ind);
                        }
                        else
                        {
                            i--;
                            cpt++;
                        }
                        
                    }
                }
            }
            return suggestions;
        }

        /// <summary>
        /// Arrondi un nombre
        /// </summary>
        /// <param name="n">Le nombre</param>
        /// <returns>L'entier arrondi</returns>
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
