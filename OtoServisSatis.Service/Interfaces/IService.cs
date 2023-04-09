using OtoServisSatis.Data.Interfaces;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Service.Interfaces
{
    public interface IService<T> : IRepository<T> where T : class,IEntity,new()
    {

    }
}
