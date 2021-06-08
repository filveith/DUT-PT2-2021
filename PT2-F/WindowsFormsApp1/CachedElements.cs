﻿using System;
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

        public static Task RefreshCache()
        {
            return Task.Run(() => albumsPasEmpruntes = Utils.AvoirAlbumsPasEmprunteDepuisUnAn());
        }

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

