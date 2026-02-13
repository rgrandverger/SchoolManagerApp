using Microsoft.EntityFrameworkCore;
using SchoolManagerApp.Models;

namespace SchoolManagerApp.Data
{
    public class SkolaDbContext : DbContext
    {
        public SkolaDbContext(DbContextOptions<SkolaDbContext> options) : base(options)
        {
        }

        public DbSet<Ucenik> Ucenik { get; set; }
    }
}