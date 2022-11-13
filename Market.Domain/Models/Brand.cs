using Market.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Models
{
    //Done
    //TODO Brands have name , description , id 
    public class Brand : BaseModel
    {
        public string? Name { get; set; }
        public string? description { get; set; }
    }
}
