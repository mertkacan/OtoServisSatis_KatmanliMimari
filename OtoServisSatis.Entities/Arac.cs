﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Arac:IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Renk { get; set; }
        public decimal Fiyati { get; set; }
        [MaxLength(50)]
        public string Modeli { get; set; }
        [MaxLength(50)]
        [Display(Name = "Kasa tipi")]
        public string KasaTipi { get; set; }
        public int ModelYili { get; set; }
        [Display(Name ="Satışta mı?")]
        public bool SatistaMi { get; set; }
        public string Notlar { get; set; }
        public virtual Marka? Marka { get; set; } // Araç ile Marka sınıfı arasındaki bağlantı. Nullable yaptık.
        [Display(Name ="Marka Adı")]
        public int MarkaId { get; set; }

    }
}
