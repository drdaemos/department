//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCDepartment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Specialty
    {
        public Specialty()
        {
            this.Group = new HashSet<Group>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }
         
        [DisplayName("����")]
        public string GlobalId { get; set; }

        [DisplayName("��������")]
        public string Name { get; set; }
    
        public virtual Plan Plan { get; set; }
        public virtual ICollection<Group> Group { get; set; }
    }
}
