using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTOs.AppUsers
{
    public class CreateOrUpdateUserDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public int? Card { get; set; }
    }
}
