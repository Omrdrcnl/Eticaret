using Eticaret.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Repository
{
    public class UrunRepository : RepositoryBase<Urun>
    {
        public UrunRepository(RepositoryContext context) : base(context) { }
       
        
        public List<Urun> UrunKategorileriniGetir(int kategoriId)
        {
            List<Urun> urunKategoriler = (from u in RepositoryContext.Urunler
                                                  join k in RepositoryContext.UrunKategoriler
                                                  on u.Id equals k.UrunId
                                                  where k.KategoriId == kategoriId
                                          select u).ToList<Urun>();
            return urunKategoriler;
        }
        public void Sil(int urunId)
        {
            RepositoryContext.Urunler.Where(k => k.Id == urunId).ExecuteDelete();
        }
    }
}
