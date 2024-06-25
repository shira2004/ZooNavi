using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T>

    {
        public T Add(T entity);
        public void Update(int id , T entity);
        public void Delete(T entity );
        public List<T> GetAll();
        public T Get(int id);
    }
}
