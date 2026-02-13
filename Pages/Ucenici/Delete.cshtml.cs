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
    public class DeleteModel : PageModel
    {
        private readonly SchoolManagerApp.Data.SkolaDbContext _context;

        public DeleteModel(SchoolManagerApp.Data.SkolaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ucenik = await _context.Ucenik.FindAsync(id);
            if (ucenik != null)
            {
                Ucenik = ucenik;
                _context.Ucenik.Remove(Ucenik);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
