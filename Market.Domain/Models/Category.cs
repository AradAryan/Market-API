using Market.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Models
{
    //Done
    //TODO Category = Name , CategoryId
    //TODO CategoryOption = Name , CategoryOptionId , CategoryId
    //TODO CategoryOptionValue = CategoryOptionValueId , Name , CategoryoptionId , ProductValueId
    public class Category : BaseModel
    {
        public string? Name { get; set; }
    }
}
