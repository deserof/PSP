using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeCompany.Infrastructure.Db;
using TradeCompany.Models;

namespace TradeCompany.Infrastructure.Services.Products
{
    public class ProductService : IProductService
    {
        private protected ProductCompanyContext Db;

        public ProductService(ProductCompanyContext db)
        {
            Db = db;
        }

        public List<Product> GetAll()
        {
            return Db.Products
                .AsNoTracking()
                .Include(x=>x.Shop)
                .Include(x=>x.Status)
                .ToList();
        }

        public void Create(Product item)
        {
            Db.Add(item);
            Db.SaveChanges();
        }

        public void Edit(Product item)
        {
            Db.Update(item);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            Db.Remove(item);
            Db.SaveChanges();
        }

        public Product GetById(int id)
        {
            return Db.Products
                .Include(x => x.Shop)
                .Include(x => x.Status)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
