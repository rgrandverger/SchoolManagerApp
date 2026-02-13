using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolManagerApp.Data;
using SchoolManagerApp.Models;

namespace SchoolManagerApp.Pages_Ucenici
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolManagerApp.Data.SkolaDbContext _context;

        public DetailsModel(SchoolManagerApp.Data.SkolaDbContext context)
        {
            _context = context;
        }

        public Ucenik Ucenik { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ucenik = await _context.Ucenik.FirstOrDefaultAsync(m => m.Id == id);

            if (ucenik is not null)
            {
                Ucenik = ucenik;

                return Page();
            }

            return NotFound();
        }
    }
}
