using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.Infrastructure.Pagination;

namespace BookStore.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly StoreDbContext _dbContext;
        
        public BookRepository(StoreDbContext dbContext)
            => _dbContext = dbContext;

        public void Add(Book book)
        {
            _dbContext.Add(book);
        }

        public void Update(Book book)
        {
            _dbContext.Update(book);
        }

        public Task<List<Book>> GetAll()
        {
            return _dbContext.Books
                .AsNoTracking()
                .ToListAsync();
        }


        public Task<IPagedData<Book>> GetList(int pageNumber, int pageSize, string keywords = null)
        {
            var query = _dbContext.Books.AsQueryable()
                    .AsNoTracking();
            
            if (!string.IsNullOrWhiteSpace(keywords))
                query = query.Where(x => x.Name.ToLower().Contains(keywords.ToLower()) || x.Author.Contains(keywords.ToLower()));

            query = query.OrderByDescending(x => x.Id);

            return query.ToPagedDataAsync(pageNumber, pageSize);
        }

        public ValueTask<Book> GetById(int id)
        {
            return _dbContext.Books.FindAsync(id);
        }

        public void Remove(Book book)
        {
            _dbContext.Remove(book);
        }

        public Task SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }

    }
}