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
    
    public partial class Uzenet
    {
        public int uzenetId { get; set; }
        public Nullable<int> jelzesId { get; set; }
        public Nullable<int> soforId { get; set; }
        public Nullable<int> vonalId { get; set; }
        public Nullable<int> buszId { get; set; }
        public Nullable<System.DateTime> datum { get; set; }
        public Nullable<decimal> lon { get; set; }
        public Nullable<decimal> lat { get; set; }
    
        public virtual Busz Busz { get; set; }
        public virtual Jelze Jelze { get; set; }
        public virtual Sofor Sofor { get; set; }
        public virtual Vonal Vonal { get; set; }
    }
}
