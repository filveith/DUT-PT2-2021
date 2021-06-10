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

        /// <summary>
        /// Met à jour le cache
        /// </summary>
        /// <returns></returns>
        public static Task RefreshCache()
        {
            return Task.Run(() => albumsPasEmpruntes = Utils.AvoirAlbumsPasEmprunteDepuisUnAn());
        }

        /// <summary>
        /// Met à jour les suggestions d'un abonné
        /// </summary>
        /// <param name="a">L'abonné</param>
        /// <returns></returns>
        public static Task RefreshSuggestions(ABONNÉS a)
        {
            return Task.Run(() =>
            {
                var test = a.AvoirSuggestions();
                if (!suggestionsParAbo.ContainsKey(a))
                {
                    suggestionsParAbo.Add(a, test);
                }
                else
                {
                    suggestionsParAbo[a] = test;
                }
            });
        }

    }
}

