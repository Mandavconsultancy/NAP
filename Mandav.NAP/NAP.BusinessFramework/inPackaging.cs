//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NAP.BusinessFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class inPackaging
    {
        public int JobID { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public Nullable<System.DateTime> DateStarted { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<int> Completedby { get; set; }
    
        public virtual JobDetail JobDetail { get; set; }
    }
}
