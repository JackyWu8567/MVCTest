//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCTest.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserRole
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int role_id { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
