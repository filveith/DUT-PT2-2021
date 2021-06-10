using System;
using System.Collections.Generic;
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
            if(album == null)
            {
                album = Utils.GetALBUM(this.CODE_ALBUM);
            }
            return album.ToString() + " | emprunté le \"" + DATE_EMPRUNT + "\" | à rendre le " + DATE_RETOUR_ATTENDUE;
        }
    }
}
