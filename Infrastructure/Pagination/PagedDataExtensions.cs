using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Pagination
{
    public static class PagedDataExtensions
    {
        
        public async static Task<IPagedData<T>> ToPagedDataAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            int start = PagedData<T>.CalculateStart(pageNumber, pageSize);
            var totalRecordsCount = await query.CountAsync();
            var items = await query.Skip(start).Take(pageSize).ToListAsync();

            return new PagedData<T>(items, pageNumber, pageSize, totalRecordsCount);
        }

        public static IPagedData<T> ToPagedData<T>(this IEnumerable<T> items, int pageNumber, int pageSize, int totalRecordsCount)
        {
            return new PagedData<T>(items, pageNumber, pageSize, totalRecordsCount);
        }
    }
}