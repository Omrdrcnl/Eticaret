using Eticaret.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Repository
{
    public class KategoriRepository : RepositoryBase<Kategori>
    {
        public KategoriRepository(RepositoryContext context) : base(context) { }
        public List<Kategori> AnaSayfaKategorileriniGetir()
        {
            List<Kategori> anasayfaKategoriler = (from k in RepositoryContext.Kategoriler.Include(a => a.UstKategori) join a in RepositoryContext.AnasayfaKategoriler
                                                  on k.Id equals a.KategoriId
                                                  select k).ToList<Kategori>();
                return anasayfaKategoriler;
        }
    }
}
