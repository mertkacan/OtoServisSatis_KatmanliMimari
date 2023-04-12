using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Musteri:IEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Adi { get; set; }
        [MaxLength(50)]
        public string Soyadi { get; set; }
        [MaxLength(11)]
        [Display(Name ="Kimlik Numarası")]
        public string? TcNo { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string? Adres { get; set; }
        [MaxLength(15)]
        public string? Telefon { get; set; }
        public string? Notlar { get; set; }
        public virtual Arac? Arac { get; set; }
        [Display(Name ="Araç")]
        public int AracId { get; set; }


    }
}
