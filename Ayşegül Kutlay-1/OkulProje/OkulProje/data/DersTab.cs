using System;
using System.Collections.Generic;

namespace OkulProje.data
{
    public partial class DersTab
    {
        public DersTab()
        {
            OgrenciDersTabs = new HashSet<OgrenciDersTab>();
        }

        public int Id { get; set; }
        public string? Ad { get; set; }
        public double? Kredi { get; set; }
        public int? OkulYonetimId { get; set; }

        public virtual OkulYonetimTab? OkulYonetim { get; set; }
        public virtual ICollection<OgrenciDersTab> OgrenciDersTabs { get; set; }
    }
}
