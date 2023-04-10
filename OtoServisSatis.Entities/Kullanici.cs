using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "{0} boş bırakılamaz.")]// Hata mesajını özelleştirdim.
        public string Adi { get; set; }
        [MaxLength(50)]
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Soyadi { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string? Telefon { get; set; }
        [MaxLength(50)]
        public string? KullaniciAdi { get; set; }
        [MaxLength(50)]
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        [Display(Name = "KEklenme Tarihi")]
        [ScaffoldColumn(false)] // Ekranda bu property için gerekli alan oluşturmaz
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        public virtual Rol? Rol { get; set; } // Nullable yaptım.
        public int RolId { get; set; }
    }
}
