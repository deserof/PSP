using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeCompany.Infrastructure.Db;
using TradeCompany.Models;

namespace TradeCompany.Infrastructure.Services.Histories
{
    public class HistoryService : IHistoryService
    {
        private protected ProductCompanyContext Db;

        public HistoryService(ProductCompanyContext db)
        {
            Db = db;
        }

        public List<History> GetAll()
        {
            return Db.Histories
                .Include(x => x.Shop)
                .AsNoTracking()
                .ToList();
        }

        public void Create(History item)
        {
            Db.Add(item);
            Db.SaveChanges();
        }

        public void Edit(History item)
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

        public History GetById(int id)
        {
            return Db.Histories
                .Include(x => x.Shop)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
