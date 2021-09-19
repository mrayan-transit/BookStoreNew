using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Data;
using BookStore.Infrastructure.Pagination;
using BookStore.Models;

namespace BookStore.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            createBookMap();
        }

        // private void createPagedDataMap<TSource, TDestination>()
        // {
        //     //Mapper.Map<List<TSource>, List<TDestination>>(new List<TSource>());
        //     CreateMap<PagedData<TSource>, PagedData<TDestination>>()
        //         .ConstructUsing(x => new PagedData<TDestination>(Mapper.Map<TSource, TDestination>(x.Items.First()), x.PageNumber, x.PageSize, x.TotalRecordsCount));
        // }

        private void createBookMap()
        {
            CreateMap<Book, BookModel>();
            CreateMap<BookModel, Book>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}