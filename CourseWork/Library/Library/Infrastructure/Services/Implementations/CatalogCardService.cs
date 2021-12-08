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
    public class CatalogCardService : ICatalogCardService
    {
        private protected LibraryContext _db;

        public CatalogCardService(LibraryContext db)
        {
            _db = db;
        }

        public void Create(CatalogCard item)
        {
            _db.CatalogCards.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _db.CatalogCards.Where(x => x.Id == id).FirstOrDefault();
            _db.CatalogCards.Remove(item);
            _db.SaveChanges();
        }

        public void Edit(CatalogCard item)
        {
            _db.CatalogCards.Update(item);
            _db.SaveChanges();
        }

        public List<CatalogCard> GetAll()
        {
            return _db.CatalogCards
                .Include(x => x.Book)
                .ToList();
        }

        public CatalogCard GetById(int id)
        {
            return _db.CatalogCards.Where(x => x.Id == id).FirstOrDefault();
        }

        public void MinusBook(int id)
        {
            var catalog = _db.CatalogCards.Where(x => x.Id == id).FirstOrDefault();

            catalog.QantityOfBook -= 1;

            _db.Update(catalog);
            _db.SaveChanges();
        }

        public void PlusBook(int id)
        {
            var catalog = _db.CatalogCards.Where(x => x.Id == id).FirstOrDefault();

            catalog.QantityOfBook += 1;

            _db.Update(catalog);
            _db.SaveChanges();
        }

        public bool IsBookGreaterThenZero(int id)
        {
            var catalog = _db.CatalogCards.Where(x => x.Id == id).FirstOrDefault();

            if (catalog.QantityOfBook > 0)
            {
                return true;
            }
            return false;
        }
    }
}
