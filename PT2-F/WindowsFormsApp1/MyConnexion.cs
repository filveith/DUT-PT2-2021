﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    partial class MusiquePT2_FEntities
    {
        public override int SaveChanges()
        {
            int n = base.SaveChanges();
            CachedElements.RefreshCache();
            return n;
        }
    }
}