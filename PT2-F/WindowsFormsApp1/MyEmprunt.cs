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
        ALBUMS album;

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
            return (int)((DATE_RETOUR_ATTENDUE - basicReturnTime).Days / (365.25 / 12));
        }
    }
}
