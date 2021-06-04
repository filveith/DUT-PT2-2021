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

    }
}
