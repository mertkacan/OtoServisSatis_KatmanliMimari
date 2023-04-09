using OtoServisSatis.Data;
using OtoServisSatis.Data.SomutSınıflar;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Service.SomutSınıflar
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context):base(context)//Repository classında Ctor oluşturduğum için burada da belirttim.
        {
           
        }
    }
}
