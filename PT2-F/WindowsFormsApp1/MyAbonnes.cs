using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
                EMPRUNTER e = new EMPRUNTER { CODE_ABONNÉ = this.CODE_ABONNÉ, CODE_ALBUM = a.CODE_ALBUM, DATE_EMPRUNT = DateTime.Now, DATE_RETOUR_ATTENDUE = retour};
                Utils.Connexion.EMPRUNTER.Add(e);
                Utils.Connexion.SaveChanges();
                return e;
            }
            catch (DbUpdateException)
            {
                Utils.RefreshDatabase();
                return null;
            }
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
        /// Retourne un dictionnary avec la liste des emprunt et la nom de l'abonne correspondant
        /// </summary>
        /// <param name="codeabo"></param>
        /// <returns></returns>
        public Dictionary<EMPRUNTER, ABONNÉS> ConsulterEmprunts()
        {
            Dictionary<EMPRUNTER, ABONNÉS> emprunts = new Dictionary<EMPRUNTER, ABONNÉS>();
            var emprunt = (from alb in Utils.Connexion.ALBUMS
                           join emp in Utils.Connexion.EMPRUNTER on alb.CODE_ALBUM equals emp.CODE_ALBUM
                           join abo in Utils.Connexion.ABONNÉS on emp.CODE_ABONNÉ equals abo.CODE_ABONNÉ
                           where abo.CODE_ABONNÉ == this.CODE_ABONNÉ
                           orderby emp.DATE_RETOUR_ATTENDUE ascending
                           select new { emprunt = emp, abonne = this }).ToList();



            foreach (var al in emprunt)
            {
                emprunts.Add(al.emprunt, al.abonne);
                //Console.WriteLine(em) ;
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


    }
}
