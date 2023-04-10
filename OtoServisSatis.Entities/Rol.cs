using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Rol:IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} Boş bırakılamaz.")]
        public string Adi { get; set; }
    }
}
