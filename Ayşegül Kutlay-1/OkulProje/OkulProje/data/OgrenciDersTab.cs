using System;
using System.Collections.Generic;

namespace OkulProje.data
{
    public partial class OgrenciDersTab
    {
        public int Id { get; set; }
        public int? DersId { get; set; }
        public int? OgrenciId { get; set; }

        public virtual DersTab? Ders { get; set; }
        public virtual OgrenciTab? Ogrenci { get; set; }
    }
}
