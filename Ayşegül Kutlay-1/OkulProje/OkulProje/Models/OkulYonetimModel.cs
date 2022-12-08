namespace OkulProje.Models
{
    public class OkulYonetimModel
    {
        public List<OkulYonetim> OkulYonetimList { get; set; }
    }

    public class OkulYonetim
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Gorevi { get; set; }
        public int? YonetimTip { get; set; }
        
    }
}
