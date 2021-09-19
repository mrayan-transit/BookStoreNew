using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BookStore.Infrastructure.Pagination;
using BookStore.Data;
using BookStore.Helper;

namespace BookStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public IndexModel(ILogger<IndexModel> logger,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task OnGetAsync()
        {
            BooksData = await _bookRepository.GetList(PageNumber, 
                PageSize ?? 4, 
                SearchKeywords);
            
            //BooksData = data.ToPagedData(_mapper);
            //BooksData = _mapper.Map<PagedData<BookModel>>(data);
        }

        public IPagedData<Book> BooksData {get; private set;}

        [FromQuery(Name = "q")]
        public string SearchKeywords {get;set;}

        [FromQuery(Name = "page")]
        public int PageNumber {get;set;} = 1;

        [FromQuery(Name = "page_size")]
        public int? PageSize {get;set;}

        // [BindProperty(SupportsGet = true, Name = "p")]
        // public int? PageNo {get;set;}

        // [BindProperty(SupportsGet = true)]
        // public int? PageSize {get;set;}
    }
}
