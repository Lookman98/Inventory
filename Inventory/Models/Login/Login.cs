using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models.Login
{
    public class Login
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password  { get; set; }
    }
}
