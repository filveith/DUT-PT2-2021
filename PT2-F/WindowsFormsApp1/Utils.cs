using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Utils
    {
        /// <summary>
        /// Permet de se connecter à la base de donnée MusquePT2_F
        /// </summary>
        public static MusiquePT2_FEntities Connexion = new MusiquePT2_FEntities();

        /// <summary>
        /// Enregistrer un nouvel abonné 
        /// </summary>
        /// <param name="nom"> Nom de l'abonné </param>
        /// <param name="prenom"> Prenom de l'abonné </param>
        /// <param name="login"> Login de l'abonné </param>
        /// <param name="mdp"> Mot de passe </param>
        /// <param name="codePays"> Code de pays d'où il vient </param>
        /// <returns> Retourne vrai si on ajoute un abonné, faux sinon </returns>
        public static ABONNÉS RegisterAbo(string nom, string prenom, string login, string mdp, int codePays)
        {
            ABONNÉS a = new ABONNÉS();
            try
            {
                // on crée un nouveau Abonné
                if (codePays > 0) a.CODE_PAYS = codePays;
                
                a.NOM_ABONNÉ = nom.Substring(0, Math.Min(nom.Length, 32));
                a.PRÉNOM_ABONNÉ = prenom.Substring(0, Math.Min(prenom.Length, 32));
                a.LOGIN_ABONNÉ = login.Substring(0, Math.Min(login.Length, 32));
                a.PASSWORD_ABONNÉ = mdp.Substring(0, Math.Min(mdp.Length, 32));
                a.creationDate = DateTime.Now;

                // ajout du nouveau Abonné
                Connexion.ABONNÉS.Add(a);
                Connexion.SaveChanges();
                return a;
            }
            catch (DbUpdateException)
            {
                return a;
            }
        }

        /// <summary>
        /// Pemret d'avoir une liste des abonnes avec des emprunts en retard de plus de 10jours
        /// </summary>
        /// <returns> Retourne liste des abonnés en retard de plus de 10 jours </returns>
        public static IQueryable<ABONNÉS> AvoirAbonneAvecEmpruntRetardDe10Jours()
        {
            var emprunt = (from emp in Connexion.EMPRUNTER
                           join abo in Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                           where emp.DATE_RETOUR == null && DbFunctions.DiffDays(emp.DATE_RETOUR_ATTENDUE, DateTime.Now) > 10
                           select abo).GroupBy(x => x.CODE_ABONNÉ).Select(y => y.FirstOrDefault());
            return emprunt;
        }

        /// <summary>
        /// Permet à l'administrateur d'avoir tout les emprunts qui ont été prolongés  
        /// </summary>
        /// <returns> Retourne tout les emprunts prolongés </returns>
        public static IQueryable<EMPRUNTER> AvoirLesEmpruntProlonger()
        {
            IQueryable<EMPRUNTER> result = (from emp in Connexion.EMPRUNTER
                                            join abo in Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                                            join alb in Connexion.ALBUMS on emp.CODE_ALBUM equals alb.CODE_ALBUM
                                            where emp.nbRallongements > 0
                                            select emp);


            return result;
        }

        /// <summary>
        /// Permet d'avoir une liste des albums qui n'ont pas été emprunté depuis 1 an
        /// </summary>
        /// <returns> Retourne les albums pas emprunté depuis 1 an</returns>
        public static IQueryable<ALBUMS> AvoirAlbumsPasEmprunteDepuisUnAn()
        {
            var liste = (from a in Connexion.ALBUMS
                         join e in Connexion.EMPRUNTER
                         on a.CODE_ALBUM equals e.CODE_ALBUM into empDept
                         from ed in empDept.DefaultIfEmpty()
                         where empDept.Count() == 0 || DbFunctions.DiffDays(ed.DATE_EMPRUNT, DateTime.Now) > 365
                         select a).GroupBy(x => x.CODE_ALBUM).Select(y => y.FirstOrDefault());

            return liste;
        }

        /// <summary>
        /// Permet d'obtenir les abonné qui n'ont pas emprunté depuis 1an
        /// </summary>
        /// <returns> Retourne les abonné qui n'ont pas emprunté depuis 1 an</returns>
        private static IEnumerable<ABONNÉS> AvoirAbosPasEmprunteDepuisUnAn()
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
                                   select a).Union(abosPasEmprunt);

            var abos = new List<ABONNÉS>(abosDejaEmprunt).Distinct();

            return abos;
        }

        /// <summary>
        /// Permet de supprimé un abonné qui n'a pas emprunté depuis 1an 
        /// </summary>
        /// <returns> Liste d'abonnés supprimés </returns>
        public static IEnumerable<ABONNÉS> SupprimerAbosPasEmpruntDepuisUnAn()
        {
            var abos = AvoirAbosPasEmprunteDepuisUnAn();
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

        /// <summary>
        /// Permet d'obtenir le top 10 des albums 
        /// </summary>
        /// <returns> Retournne les 10 albums les plus empruntés</returns>
        public static List<ALBUMS> AvoirTopAlbum()
        {
            var nbEmprunt = (from emp in Connexion.EMPRUNTER
                             select emp.CODE_ALBUM).Count();

            var top = (from alb in Connexion.ALBUMS
                       join emp in Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                       group alb by alb.CODE_ALBUM into groupés
                       orderby groupés.Count() descending
                       select groupés).Take(10);
            List<ALBUMS> al = new List<ALBUMS>();
            foreach (var v in top)
            {
                al.Add(v.First());
            }

            return al;
        }

        /// <summary>
        /// Permet d'avoir la liste des pays 
        /// </summary>
        /// <returns> Retourne tout les pays </returns>
        public static IQueryable<PAYS> AvoirListeDesPays()
        {
            var pays = from p in Connexion.PAYS
                       orderby p.CODE_PAYS ascending
                       select p;
            return pays;
        }

        /// <summary>
        /// Rafraichir la base 
        /// </summary>
        public static void RefreshDatabase()
        {
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

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static IQueryable<ABONNÉS> GetAllAbonnes()
        {
            var abos = from ab in Connexion.ABONNÉS
                       select ab;
            return abos;
        }

    }
}
