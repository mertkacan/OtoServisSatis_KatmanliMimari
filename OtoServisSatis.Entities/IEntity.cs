using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public interface IEntity // Interface'i class lara Inherit ederek Id propertysini vermiş olucam.
    {
        public int Id { get; set; }
    }
}
