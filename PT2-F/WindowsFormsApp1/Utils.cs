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

        public List<ABONNÉS> AvoirAbonneAvecEmpruntRetardDe10Jours()
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
    }
}
