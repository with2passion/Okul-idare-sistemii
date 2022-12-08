using System;
using System.Collections.Generic;

namespace OkulProje.data
{
    public partial class OkulYonetimTab
    {
        public OkulYonetimTab()
        {
            DersTabs = new HashSet<DersTab>();
        }

        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public string? Gorevi { get; set; }
        public int? YonetimTip { get; set; }

        public virtual ICollection<DersTab> DersTabs { get; set; }
    }
}
