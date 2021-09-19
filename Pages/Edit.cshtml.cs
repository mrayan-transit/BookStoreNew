using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class EditModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        private readonly IWebHostEnvironment _host;

        public EditModel(IBookRepository bookRepository,
            IMapper mapper,
            IWebHostEnvironment host)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _host = host;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var book = await _bookRepository.GetById(Id);
            if (book == null)
                return NotFound();

            BookModel = _mapper.Map<BookModel>(book);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var book = await _bookRepository.GetById(Id);
            if (book == null)
                return NotFound();

            await BookModel.SaveCover(_host);

            _mapper.Map(BookModel, book);
            _bookRepository.Update(book);

            await _bookRepository.SaveChanges();
            return RedirectToPage("Index");
        }

        [BindProperty]
        public BookModel BookModel {get;set;}

        [BindProperty(SupportsGet = true)]
        public int Id {get;set;}
    }
}
