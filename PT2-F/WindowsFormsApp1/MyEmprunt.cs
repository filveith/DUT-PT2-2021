using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class EMPRUNTER
    {
        public override string ToString()
        {
            ABONNÉS a = Utils.GetABONNÉ(this.CODE_ABONNÉ);
            ALBUMS al = Utils.GetALBUM(this.CODE_ALBUM);
            return "Emprunt de l'album \"" + al + "\" par l'abonné \"" + a + "\""; 
        }
    }
}
