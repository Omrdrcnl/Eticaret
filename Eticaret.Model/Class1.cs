using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Model
{
    [Table("tblKategori")]
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int UstKategoriId { get; set; }
        public int Sira { get; set; }
        public string Foto { get; set; }
        public bool Aktif  { get; set; }

       


    }
}