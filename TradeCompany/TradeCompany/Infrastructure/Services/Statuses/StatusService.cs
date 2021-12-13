using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeCompany.Infrastructure.Db;
using TradeCompany.Models;

namespace TradeCompany.Infrastructure.Services.Statuses
{
    public class StatusService : IStatusService
    {
        private protected ProductCompanyContext Db;

        public StatusService(ProductCompanyContext db)
        {
            Db = db;
        }

        public List<Status> GetAll()
        {
            return Db.Statuses
                .AsNoTracking()
                .ToList();
        }

        public void Create(Status item)
        {
            Db.Add(item);
            Db.SaveChanges();
        }

        public void Edit(Status item)
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

        public Status GetById(int id)
        {
            return Db.Statuses
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
