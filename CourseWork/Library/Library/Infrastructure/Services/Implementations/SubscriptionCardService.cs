using Library.Entities;
using Library.Infrastructure.Db;
using Library.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services.Implementations
{
    public class SubscriptionCardService : ISubscriptionCardService
    {
        private protected LibraryContext _db;

        public SubscriptionCardService(LibraryContext db)
        {
            _db = db;
        }

        public void Create(SubscriptionCard item)
        {
            _db.SubscriptionCards.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _db.SubscriptionCards.Where(x => x.Id == id).FirstOrDefault();
            _db.SubscriptionCards.Remove(item);
            _db.SaveChanges();
        }

        public void Edit(SubscriptionCard item)
        {
            _db.SubscriptionCards.Update(item);
            _db.SaveChanges();
        }

        public List<SubscriptionCard> GetAll()
        {
            return _db.SubscriptionCards
                .Include(x=>x.ReaderList)
                .Include(x=>x.CatalogCard)
                .Include(x=>x.CatalogCard.Book)
                .ToList();
        }

        public SubscriptionCard GetById(int id)
        {
            return _db.SubscriptionCards.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
