using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class EDITEURS
    {
        public override string ToString()
        {
            return "\"" + NOM_EDITEUR + "\" basé en " + PAYS.ToString();
        }
    }
}
