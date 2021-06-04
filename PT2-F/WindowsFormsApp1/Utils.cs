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

        public static void prolongerEmprunt(int codeAbonne, int codeAlbumSelected)
        {

            EMPRUNTER emprunt = (from emp in Connexion.EMPRUNTER
                                where emp.CODE_ABONNÉ == codeAbonne && emp.CODE_ALBUM == codeAlbumSelected
                                select emp).First();

            if (emprunt.nbRallongements != 1)
            {
                emprunt.DATE_RETOUR_ATTENDUE = emprunt.DATE_RETOUR_ATTENDUE.AddMonths(1);
                emprunt.nbRallongements = 1;
                Console.WriteLine("Rallongement effectué");
            } else
            {
                Console.WriteLine("Vous avez déjà rallonger cet emprunt :/");
            }
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

        public static void prolongerTousEmprunts(int codeAbonne)
        {
            int i = 0;
            var emprunts = from emp in Connexion.EMPRUNTER
                           where emp.CODE_ABONNÉ == codeAbonne
                           select emp;

            foreach (EMPRUNTER e in emprunts)
            {
                i++;
                if (e.nbRallongements != 1)
                {
                    e.DATE_RETOUR_ATTENDUE = e.DATE_RETOUR_ATTENDUE.AddMonths(1);
                    e.nbRallongements = 1;
                }
            }
            Console.WriteLine(i + " rallongement(s) effectué(s)");
        }
    }
}
