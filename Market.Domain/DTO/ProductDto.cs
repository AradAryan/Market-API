using Market.Domain.DTO;
using Market.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Models
{
    public class ProductDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid BrandId { get; set; }
    }
}
