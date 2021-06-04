using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Utils
    {
        private static MusiquePT2_FEntities Connexion = new MusiquePT2_FEntities();

        public List<EMPRUNTER> AvoirLesEmpruntProlonger()
        {
            List<EMPRUNTER> result = (from emp in Connexion.EMPRUNTER
                          join abo in Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                          join alb in Connexion.ALBUMS on emp.CODE_ALBUM equals alb.CODE_ALBUM
                          where emp.nbRallongements > 0
                          select emp).ToList();

            return result;
        }

    }
}
