using Market.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Models
{
    public class ProductOption : BaseModel
    {
        public string? Name { get; set; }
    }
}
