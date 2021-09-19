using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Data;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        private readonly IWebHostEnvironment _host;

        public CreateModel(IBookRepository bookRepository,
            IMapper mapper,
            IWebHostEnvironment host)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _host = host;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await BookModel.SaveCover(_host);
            
            var book = _mapper.Map<Book>(BookModel);
            _bookRepository.Add(book);
            await _bookRepository.SaveChanges();

            return RedirectToPage("Index");
        }

        [BindProperty]
        public BookModel BookModel {get;set;} = new BookModel() { PublishDate = DateTime.Now };
    }
}
