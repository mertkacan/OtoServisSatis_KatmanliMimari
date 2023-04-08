using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Kullanici:IEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Adi { get; set; }
        [MaxLength(50)]
        public string Soyadi { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Telefon { get; set; }
        [MaxLength(50)]
        public string KullaniciAdi { get; set; }
        [MaxLength(50)]
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        public DateTime EklenmeTarihi { get; set; }= DateTime.Now;
        public virtual Rol? Rol { get; set; } // Nullable yaptım.
        public int RolId { get; set; }
    }
}
