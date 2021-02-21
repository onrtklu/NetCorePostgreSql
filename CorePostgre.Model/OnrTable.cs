using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorePostgre.Model
{
    public class OnrTable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
