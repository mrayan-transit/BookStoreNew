using System.Collections.Generic;
using AutoMapper;
using BookStore.Infrastructure.Pagination;

namespace BookStore.Helper
{
    public static class ArrayExtensions
    {
        public static IPagedData<TDestination> ToPagedData<TSource,TDestination>(this IPagedData<TSource> data, IMapper mapper)
        {
            return new PagedData<TDestination>(mapper.Map<IEnumerable<TDestination>>(data.Items), data.PageNumber, data.PageSize, data.TotalRecordsCount);
        }
    }
}