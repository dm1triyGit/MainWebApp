using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id);

        T GetAll<T>();

        bool Save<T>(T model);

        bool Update<T>(T model);
    }
}
