//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OkulYonetimTab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OkulYonetimTab()
        {
            this.DersTab = new HashSet<DersTab>();
        }
    
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Gorevi { get; set; }
        public Nullable<int> YonetimTip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DersTab> DersTab { get; set; }
    }
}
