using OkulProje.data;

namespace OkulProje.Models
{
    public class OgrenciDersModel
    {
        public List<OgrenciDers> OgrenciDersList { get; set; }
    }

    public class OgrenciDers
    {
        public int Id { get; set; }
        public int? DersId { get; set; }
        public int? OgrenciId { get; set; }


    }
}