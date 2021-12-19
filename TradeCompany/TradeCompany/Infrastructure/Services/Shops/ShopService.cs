using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeCompany.Infrastructure.Db;
using TradeCompany.Models;

namespace TradeCompany.Infrastructure.Services.Shops
{
    public class ShopService : IShopService
    {
        private protected ProductCompanyContext Db;

        public ShopService(ProductCompanyContext db)
        {
            Db = db;
        }

        public List<Shop> GetAll()
        {
            return Db.Shops
                .AsNoTracking()
                .Include(x=>x.Products)
                .ToList();
        }

        public void Create(Shop item)
        {
            Db.Add(item);
            Db.SaveChanges();
        }

        public void Edit(Shop item)
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

        public Shop GetById(int id)
        {
            return Db.Shops
                .AsNoTracking()
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
