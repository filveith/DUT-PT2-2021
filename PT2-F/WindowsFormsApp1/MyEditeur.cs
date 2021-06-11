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
            PAYS p = PAYS;
            if (p != null)
            {
                return "\"" + NOM_EDITEUR.Trim() + "\" basé en " + PAYS.ToString();
            }
            else
            {
                return "\"" + NOM_EDITEUR.Trim() + "\"";
            }
        }
    }
}
