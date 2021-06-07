using System;
using System.Collections.Generic;
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
    }
}
