using Market.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Models
{
    //Done with Conflicts
    //TODO Shop = Id guid , Name , Createdate, ExpireDate 
    //TODO Shop , Account , Reseller Inherit from Users
    //TODO UsersAddress = UserId , AddressId
    //TODO Address = Id , latitude, longitude , detail , CityProvienceZoneId
    public class Shop : BaseModel
    {
        public string? Name { get; set; }
        public DateTime ExpireDate { get; set; }
        public Guid Account { get; set; }
    }
}
