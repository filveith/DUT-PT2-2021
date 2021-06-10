﻿using System;
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
            catch (DbUpdateException e)
            {
                Console.WriteLine("erreur : " + e);
                Utils.RefreshDatabase();
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Permet de rendre un album
        /// </summary>
        /// <param name="album">L'album</param>
        public bool Rendre(ALBUMS album)
        {
            EMPRUNTER emprunt = (from emp in Utils.Connexion.EMPRUNTER
                                 where emp.CODE_ABONNÉ == this.CODE_ABONNÉ && emp.CODE_ALBUM == album.CODE_ALBUM
                                 select emp).FirstOrDefault();

            if (emprunt != null)
            {
                emprunt.DATE_RETOUR = DateTime.Now;
                return true;
            }
            return false;
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

        public Dictionary<GENRES, double> GetPreferences()
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

        public HashSet<ALBUMS> AvoirSuggestions()
        {
            var pref = GetPreferences();
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


        public void ChangePassword(string newPass)
        {
            this.PASSWORD_ABONNÉ = Utils.ComputeSha256Hash(newPass);
            Utils.Connexion.SaveChanges();
        }

        

    }
}
