using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class ALBUMS
    {
        /// <summary>
        /// Renvoie le titre de l'album
        /// </summary>
        /// <returns>Le titre</returns>
        public override string ToString()
        {
            return this.TITRE_ALBUM.Trim();
        }

        /// <summary>
        /// Renvoie la pochette
        /// </summary>
        /// <returns>L'image de la pochette</returns>
        public Image getPochette()
        {
            if (POCHETTE != null && POCHETTE.Length != 0)
            {
                return Utils.byteArrayToImage(POCHETTE);
            }
            return null;
        }


    }
}
