using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICage<T>:IService<T>

    {
        List<T> GetByCageId(int[] cagesIds);
    }
}
