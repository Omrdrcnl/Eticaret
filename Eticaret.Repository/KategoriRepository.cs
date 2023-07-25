using Eticaret.Model;
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

    }
}
