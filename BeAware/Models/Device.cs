using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAware.Models
{
    public class Device
    {
        public string WhatsApp { get; set; }
        public string Messenger { get; set; }
        [Key]
        public string Name { get; set; }
        [Column(TypeName ="jsonb")]
        public List<Location> Map { get; set; }
    }
}