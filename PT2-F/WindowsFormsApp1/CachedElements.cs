using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class CachedElements
    {
        public static List<ALBUMS> allAlbums = Utils.Connexion.ALBUMS.ToList();
        public static List<PAYS> allPays = Utils.Connexion.PAYS.ToList();
    }
}
