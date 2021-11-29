using Library.Entities;

namespace Library.Infrastructure.Services.Interfaces
{
    public interface ICatalogCardService : IService<CatalogCard>
    {
        void MinusBook(int id);
        bool IsBookGreaterThenZero(int id);
    }
}
