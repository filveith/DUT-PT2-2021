using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    partial class MusiquePT2_FEntities
    {
        /// <summary>
        /// Sauve les changements effectués
        /// </summary>
        /// <returns></returns>
        public new async Task SaveChanges()
        {
            int n = base.SaveChanges();
            await Task.Run(() => CachedElements.RefreshCache());
        }
    }
}
