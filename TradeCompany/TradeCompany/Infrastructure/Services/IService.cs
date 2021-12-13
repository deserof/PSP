using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeCompany.Infrastructure.Services
{
    public interface IService<T>
    {
        List<T> GetAll();

        void Create(T item);

        void Edit(T item);

        void Delete(int id);

        T GetById(int id);
    }
}
