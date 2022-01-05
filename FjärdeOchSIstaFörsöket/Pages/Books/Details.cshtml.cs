#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FjärdeOchSIstaFörsöket.Data;
using FjärdeOchSIstaFörsöket.Models;

namespace FjärdeOchSIstaFörsöket.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly FjärdeOchSIstaFörsöket.Data.ApplicationDbContext _context;

        public DetailsModel(FjärdeOchSIstaFörsöket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
