//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCDepartment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ScheduleWeek
    {
        public int Id { get; set; }
        public int Lectures { get; set; }
        public int Labs { get; set; }
        public int Practices { get; set; }
        public int ExamWorks { get; set; }
        public int WeekNumber { get; set; }
    
        public virtual Schedule Schedule { get; set; }
    }
}
