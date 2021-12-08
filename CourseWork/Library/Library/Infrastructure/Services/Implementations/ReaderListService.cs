using ClosedXML.Excel;
using Library.Entities;
using Library.Infrastructure.Db;
using Library.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services.Implementations
{
    public class ReaderListService : IReaderListService
    {
        private protected LibraryContext _db;

        public ReaderListService(LibraryContext db)
        {
            _db = db;
        }

        public void Create(ReaderList item)
        {
            _db.ReaderLists.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _db.ReaderLists.Where(x => x.Id == id).FirstOrDefault();
            _db.ReaderLists.Remove(item);
            _db.SaveChanges();
        }

        public void Edit(ReaderList item)
        {
            _db.ReaderLists.Update(item);
            _db.SaveChanges();
        }

        public List<ReaderList> GetAll()
        {
            return _db.ReaderLists.ToList();
        }

        public ReaderList GetById(int id)
        {
            return _db.ReaderLists.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
