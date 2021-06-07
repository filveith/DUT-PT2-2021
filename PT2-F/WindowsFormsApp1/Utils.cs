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

        public static List<ABONNÉS> AvoirAbosPasEmprunteDepuisUnAn()
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
    }
}
