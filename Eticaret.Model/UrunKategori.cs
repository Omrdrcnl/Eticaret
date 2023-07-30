using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Model
{

    [Table("tblUrunKategori")]
    public class UrunKategori
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }

        public int UrunId { get; set; }
        

        public virtual Kategori? Kategori { get; set;}
        public virtual ICollection<Kategori>? Kategoriler { get; set; }
        public virtual Urun? Urun { get; set;}
    }

    

}
