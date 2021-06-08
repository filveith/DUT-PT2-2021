using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CachedElements
    {

        public static IQueryable<ALBUMS> albumsPasEmpruntes { get; private set; }

        public static Dictionary<ABONNÉS, HashSet<ALBUMS>> suggestionsParAbo { get; private set; } = new Dictionary<ABONNÉS, HashSet<ALBUMS>>();

        public async static Task RefreshCache()
        {
            albumsPasEmpruntes = await Task.Run(() => Utils.AvoirAlbumsPasEmprunteDepuisUnAn());

        }

        public async static Task RefreshSuggestions(ABONNÉS a)
        {
            try
            {
                var test = await Task.Run(a.AvoirSuggestions);
                if (!suggestionsParAbo.ContainsKey(a))
                {
                    suggestionsParAbo.Add(a, test);
                }
                else
                {
                    suggestionsParAbo[a] = test;
                }
            }
            catch (EntityException) { }
            catch (InvalidOperationException) { }
        }
    }
}
