//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Garaz
    {
        public int garazsid { get; set; }
        public Nullable<int> buszId { get; set; }
        public Nullable<int> buszAllapotId { get; set; }
        public Nullable<System.DateTime> datum { get; set; }
    
        public virtual Busz Busz { get; set; }
        public virtual BuszAllapot BuszAllapot { get; set; }
    }
}
