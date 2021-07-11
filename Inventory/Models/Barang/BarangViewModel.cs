using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models.Barang
{
    public class BarangViewModel
    {
        public List<Barang> Barangs { get; set; }
        public string StesenName { get; set; }
        public string DaerahName { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}
