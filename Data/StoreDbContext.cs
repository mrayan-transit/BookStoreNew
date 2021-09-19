using System;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class StoreDbContext : DbContext
    {

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Book> Books {get;set;}
    
    }
}