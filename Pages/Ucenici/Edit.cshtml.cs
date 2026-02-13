using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagerApp.Data;
using SchoolManagerApp.Models;

namespace SchoolManagerApp.Pages_Ucenici
{
    public class EditModel : PageModel
    {
        private readonly SchoolManagerApp.Data.SkolaDbContext _context;

        public EditModel(SchoolManagerApp.Data.SkolaDbContext context)
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

            var ucenik =  await _context.Ucenik.FirstOrDefaultAsync(m => m.Id == id);
            if (ucenik == null)
            {
                return NotFound();
            }
            Ucenik = ucenik;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ucenik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UcenikExists(Ucenik.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UcenikExists(int id)
        {
            return _context.Ucenik.Any(e => e.Id == id);
        }
    }
}
