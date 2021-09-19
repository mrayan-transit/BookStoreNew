using System.Collections.Generic;

namespace BookStore.Infrastructure.Pagination
{
    public interface IPagedData<T>
    {
        IEnumerable<T> Items {get;}

        int TotalRecordsCount {get;}

        int TotalPagesCount { get; }

        int PageNumber {get;}

        int PageSize {get;}
    }
}