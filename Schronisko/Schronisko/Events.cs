//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schronisko
{
    using System;
    using System.Collections.Generic;
    
    public partial class Events
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Events()
        {
            this.UsersEvents = new HashSet<UsersEvents>();
        }
    
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public System.TimeSpan time { get; set; }
        public string description { get; set; }
        public bool approved { get; set; }
        public int id_user { get; set; }
        public Nullable<int> id_dog { get; set; }
    
        public virtual Dogs Dogs { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersEvents> UsersEvents { get; set; }
    }
}
