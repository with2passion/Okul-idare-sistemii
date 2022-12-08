using OkulProje.data;

namespace OkulProje.Models
{
    public class DersModel
    {
        public List<Ders> DersList { get; set; }
    }

    public class Ders
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public double? Kredi { get; set; }
        public int? OkulYonetimId { get; set; }

        
    }
}