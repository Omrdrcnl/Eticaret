using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext context;

        private KategoriRepository kategoriRepository;
        private KullaniciRepository kullaniciRepository;
        private RolRepository rolRepository;

        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
           
        }

        public KategoriRepository KategoriRepository { 
            get { if(kategoriRepository == null)
                
                    kategoriRepository = new KategoriRepository(context);
                    return kategoriRepository;
                }
        }  

        public KullaniciRepository KullaniciRepository
        {
            get
            {
                if(kullaniciRepository == null)
                    kullaniciRepository = new KullaniciRepository(context);
                return KullaniciRepository;
            }
        }

        public RolRepository RolRepository
        {
            get
            {
                if (rolRepository == null)
                    rolRepository = new RolRepository(context);
                return rolRepository;
            }
        }

        //public KullaniciRepository kullaniciRepository
        //{ 
        //    get { if(kullaniciRepository == null)

        //            kullaniciRepository = new KullaniciRepository(context);
        //            return kullaniciRepository;
        //        }
          


        public void SaveChanges()
        {
            context.SaveChanges();
        }
       
    }
}
