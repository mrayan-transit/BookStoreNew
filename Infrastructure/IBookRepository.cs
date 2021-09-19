using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Infrastructure.Pagination;

namespace BookStore.Infrastructure
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<IPagedData<Book>> GetList(int start, int limit, string keywords = null);

        ValueTask<Book> GetById(int id);

        Task SaveChanges();

        void Add(Book book);

        void Remove(Book book);

        void Update(Book book);
    }
}