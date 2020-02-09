using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAware.Models
{
    public class User
    {
        public string Name { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        [Column(TypeName = "jsonb")]
        public List<Device> Devices { get; set; }
    }
}
