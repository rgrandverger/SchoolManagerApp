using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagerApp.Data;
using SchoolManagerApp.Models;

namespace SchoolManagerApp.Pages_Ucenici
{
    public class CreateModel : PageModel
    {
        private readonly SchoolManagerApp.Data.SkolaDbContext _context;

        public CreateModel(SchoolManagerApp.Data.SkolaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ucenik Ucenik { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ucenik.Add(Ucenik);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
