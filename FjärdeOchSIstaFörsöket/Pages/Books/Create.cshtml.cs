#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FjärdeOchSIstaFörsöket.Data;
using FjärdeOchSIstaFörsöket.Models;
using System.ComponentModel.DataAnnotations;

namespace FjärdeOchSIstaFörsöket.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly FjärdeOchSIstaFörsöket.Data.ApplicationDbContext _context;

        public CreateModel(FjärdeOchSIstaFörsöket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Author"] = new SelectList(_context.Authors.OrderBy(x => x.AuthorName), nameof(Author.Id), nameof(Author.AuthorName));
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Author is required.")]
        public int AuthorId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Connects the author with a book.
            var author = _context.Authors.First(x => x.Id == AuthorId);
            Book.Author = author;

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
