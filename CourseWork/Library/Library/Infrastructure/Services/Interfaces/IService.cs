using System.Collections.Generic;

namespace Library.Infrastructure.Services.Interfaces
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
