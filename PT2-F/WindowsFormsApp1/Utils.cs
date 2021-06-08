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
        public static MusiquePT2_FEntities Connexion { get; private set; } = new MusiquePT2_FEntities();
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
        public static Task<List<ALBUMS>> AvoirAlbumsPasEmprunteDepuisUnAn()
        {
            var liste = (from a in Connexion.ALBUMS
                         join e in Connexion.EMPRUNTER
                         on a.CODE_ALBUM equals e.CODE_ALBUM into empDept
                         from ed in empDept.DefaultIfEmpty()
                         where empDept.Count() == 0 || DbFunctions.DiffDays(ed.DATE_EMPRUNT, DateTime.Now) > 365
                         select a).GroupBy(x => x.CODE_ALBUM).Select(y => y.FirstOrDefault()).ToListAsync();

            return liste;
        }

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
            top.ToList().ForEach(v => al.Add(v.First()));

            return al;
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


        public static List<ABONNÉS> getListAbonnes()
        {
            List<ABONNÉS> allAbonnes = new List<ABONNÉS>();
            var abos = from ab in Connexion.ABONNÉS
                       select ab;

            foreach(ABONNÉS a in abos)
            {
                allAbonnes.Add(a);
            }
            return allAbonnes;
        }

        public static bool FaireEmprunt(int codeAbo, ALBUMS alb)
        {

        }

        public static List<ABONNÉS> getListAbonnes()
        {
            List<ABONNÉS> allAbonnes = new List<ABONNÉS>();
            var abos = from ab in Connexion.ABONNÉS
                       select ab;

            foreach(ABONNÉS a in abos)
            {
                allAbonnes.Add(a);
            }
            return allAbonnes;
        }

        public static bool FaireEmprunt(int codeAbo, ALBUMS alb)
        {

        }
    }
}
