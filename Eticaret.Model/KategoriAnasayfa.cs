using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Model
{
    [Table("tblKategoriAnasayfa")]
    public class KategoriAnasayfa
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int Sira { get; set; }
    }
}
