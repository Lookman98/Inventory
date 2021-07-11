using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models.Daerah
{
    public class Daerah
    {
        [Key]
        public Guid IdDaerah { get; set; }
        public string Name { get; set; }
    }
}
