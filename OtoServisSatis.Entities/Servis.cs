using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Servis:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servise geliş tarihi")]
        public DateTime ServiseGelisTarihi { get; set; }
        [MaxLength(150)]
        [Display(Name = "Araç Sorunu")]
        public string AracSorunu { get; set; }
        public decimal ServisUcreti { get; set; }
        [Display(Name = "Servisten çıkış tarihi")]
        public DateTime ServistenCikisTarihi { get; set; }
        public string? YapilanIslemler { get; set; }
        [Display(Name = "Garanti kapsamında mı?")]
        public bool GarantiKapsamindaMi { get; set; }
        [MaxLength(15)]
        public string AracPlaka { get; set; }
        [MaxLength(50)]
        public string Marka { get; set; }
        [MaxLength(50)]
        public string? Model { get; set; }
        [MaxLength(50)]
        public string? KasaTipi { get; set; }
        public string? SaseNo { get; set; }
        public string Notlar { get; set; }
    }
}
