using System;
using System.Collections.Generic;

namespace OkulProje.data
{
    public partial class OgrenciTab
    {
        public OgrenciTab()
        {
            OgrenciDersTabs = new HashSet<OgrenciDersTab>();
        }

        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public DateTime? KayitTarih { get; set; }
        public int? OgrenciNo { get; set; }
        public DateTime? Dtarih { get; set; }
        public string? Bolum { get; set; }

        public virtual ICollection<OgrenciDersTab> OgrenciDersTabs { get; set; }
    }
}
