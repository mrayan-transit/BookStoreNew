using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Pagination
{
    public class PagedData<T> : IPagedData<T>
    {
        public PagedData(IEnumerable<T> items, 
            int pageNumber, 
            int pageSize, 
            int totalRecordsCount)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecordsCount = totalRecordsCount;

            TotalPagesCount = calculateTotalPagesCount(totalRecordsCount, pageSize);
        }

        #region Calculation Methods

        private int calculateTotalPagesCount(int totalRecordsCount, int pageSize)
        {
            int pagesCount = Math.DivRem(totalRecordsCount, pageSize, out int remainder);
            if (remainder > 0)
                pagesCount++;
                
            return pagesCount;
        }

        public static int CalculateStart(int pageNumber, int pageSize)
        {
            return (pageNumber - 1) * pageSize;
        }

        #endregion

        public IEnumerable<T> Items {get; }

        public int TotalRecordsCount {get;}

        public int TotalPagesCount { get; }

        public int PageNumber {get;}

        public int PageSize {get;}

    }
}