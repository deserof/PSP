using Library.Entities;
using Library.Infrastructure.Db;
using Library.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services.Implementations
{
    public class BookService : IBookService
    {
        private protected LibraryContext _db;

        public BookService(LibraryContext db)
        {
            _db = db;
        }

        public void Create(Book item)
        {
            _db.Books.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _db.Books.Where(x => x.Id == id).FirstOrDefault();
            _db.Books.Remove(item);
            _db.SaveChanges();
        }

        public void Edit(Book item)
        {
            _db.Books.Update(item);
            _db.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _db.Books.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
