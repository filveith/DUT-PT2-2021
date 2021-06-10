using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class EMPRUNTER
    {
        public int nbRallongements => this.NombreRallongements();
        
        /// <summary>
        /// Renvoie les informations sur cet emprunt
        /// </summary>
        /// <returns>Les informations</returns>
        public override string ToString()
        {

            return ALBUMS.ToString() + " | emprunté le \"" + DATE_EMPRUNT + "\" | à rendre le " + DATE_RETOUR_ATTENDUE;
        }

        public int NombreRallongements()
        {
            var alb = this.ALBUMS;
            var genre = alb.GENRES;
            DateTime basicReturnTime = DATE_EMPRUNT.AddDays(genre.DÉLAI);
            int diffMonth = (DATE_RETOUR_ATTENDUE.Month - basicReturnTime.Month) + 12 * (DATE_RETOUR_ATTENDUE.Year - basicReturnTime.Year); ;
            return diffMonth;
        }
    }
}
