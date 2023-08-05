﻿using Eticaret.Model;
using Eticaret.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Repository
{
    public class KullaniciRepository : RepositoryBase<Kullanici>
    {
        public KullaniciRepository (RepositoryContext context) : base(context) { }

        public List<V_AktifKullanicilar> AktifKullanicilarGetir()
        {
            return RepositoryContext.AktifKullanicilar.ToList<V_AktifKullanicilar>();
        }

    }
}
