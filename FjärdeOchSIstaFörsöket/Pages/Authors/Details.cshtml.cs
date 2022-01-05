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

namespace FjärdeOchSIstaFörsöket.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly FjärdeOchSIstaFörsöket.Data.ApplicationDbContext _context;

        public DetailsModel(FjärdeOchSIstaFörsöket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
