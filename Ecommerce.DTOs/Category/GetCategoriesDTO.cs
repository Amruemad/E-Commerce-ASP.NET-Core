using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTOs.Category
{
    public class GetCategoriesDTO
    {
        public int CatId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
