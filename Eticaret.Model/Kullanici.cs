using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Model
{
    [Table("tblKullanici")]
    public class Kullanici
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public int RolId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime? GuncellemeTarih { get; set; }
        public bool? EmailOnay { get; set; }
        public string? EmailOnayTarih { get; set; }
        public bool? Aktif { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
