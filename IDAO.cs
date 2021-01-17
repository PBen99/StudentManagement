using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp
{
    public interface IDAO<T>
    {
        List<T> GetAll();

        List<T> GetByID(int id);

        List<T> GetByName(string name);

        bool Update(T obj);

        bool Delete(T obj);

        bool Add(T obj);
    }
}
