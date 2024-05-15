using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Address { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public int? Card { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
