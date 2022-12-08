namespace OkulProje.Models
{
    public class OgrenciModel
    {
        public List<Ogrenci> OgrenciList { get; set; }
    }

    public class Ogrenci
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public DateTime? KayitTarih { get; set; }
        public int? OgrenciNo { get; set; }
        public DateTime? Dtarih { get; set; }
        public string Bolum { get; set; }
    }
}
