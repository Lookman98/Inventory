using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models.Stesen
{
    public class Stesen
    {
        [Key]
        public long IdStesen { get; set; }
        public string Name { get; set; }
        public Guid IdDaerah { get; set; }
        
    }
}
