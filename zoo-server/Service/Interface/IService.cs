using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IService<T>
    {
        T Add(T item);
        List<T> GetAll();
        T GetById(int id);
        void Update(int id,T entity);
        void Delete(int id);

       


    }
}
