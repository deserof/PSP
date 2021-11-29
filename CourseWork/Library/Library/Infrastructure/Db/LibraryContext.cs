using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Db
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<CatalogCard> CatalogCards { get; set; }
        public DbSet<ReaderList> ReaderLists { get; set; }
        public DbSet<SubscriptionCard> SubscriptionCards { get; set; }
    }
}
