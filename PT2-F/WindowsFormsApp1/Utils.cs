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
