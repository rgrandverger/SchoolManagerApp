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
    public class IndexModel : PageModel
    {
        private readonly SchoolManagerApp.Data.SkolaDbContext _context;

        public IndexModel(SchoolManagerApp.Data.SkolaDbContext context)
        {
            _context = context;
        }

        public IList<Ucenik> Ucenik { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Ucenik = await _context.Ucenik.ToListAsync();
        }
    }
}
