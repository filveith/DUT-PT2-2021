using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CachedElements
    {

        public static List<ALBUMS> albumsPasEmpruntes { get; private set; }

        public async static void RefreshCache()
        {
            albumsPasEmpruntes = await Utils.AvoirAlbumsPasEmprunteDepuisUnAn(); 
        }
    }
}
