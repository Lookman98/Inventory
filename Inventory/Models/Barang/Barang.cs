using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models.Barang
{
    public class Barang
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdBarang { get; set; }
        public string Name { get; set; }
        public long IdStesen { get; set; }
        public Guid IdDaerah { get; set; }
        public int Warranty { get; set; }
        public DateTime TarikhTerima { get; set; }
        [Display(Name = "Tarikh Serah")]
        public DateTime TarikhSerah { get; set; }
        public DateTime TarikhTamat { get; set; }

        //public string? StesenName { get; set; }
        //public string? DaerahName { get; set; }

    }
}
