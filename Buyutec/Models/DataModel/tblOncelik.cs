//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Buyutec.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOncelik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOncelik()
        {
            this.tblAltSurecs = new HashSet<tblAltSurec>();
            this.tblSurecs = new HashSet<tblSurec>();
        }
    
        public int oncelikId { get; set; }
        public string oncelikAdi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAltSurec> tblAltSurecs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSurec> tblSurecs { get; set; }
    }
}
