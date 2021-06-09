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

        public override string ToString()
        {
            return this.TITRE_ALBUM.Trim();
        }

        public Image getPochette()
        {
            return Utils.byteArrayToImage(POCHETTE);
        }

       
    }
}
