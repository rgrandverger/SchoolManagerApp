namespace SchoolManagerApp.Models
{
    public class Ucenik
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public DateTime DatumRodenja { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal Prosjek { get; set; }
    }
}