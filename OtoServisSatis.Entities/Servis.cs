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
        public DateTime ServiseGelisTarihi { get; set; }
        [MaxLength(150)]
        public string AracSorunu { get; set; }
        public decimal ServisUcreti { get; set; }
        public DateTime ServistenCikisTarihi { get; set; }
        public string? YapilanIslemler { get; set; }
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
