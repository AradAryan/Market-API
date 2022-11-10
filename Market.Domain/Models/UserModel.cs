using Market.Domain.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Models
{
    public class UserModel : IdentityUser
    {
        public RoleModel? Role { get; set; }

    }

}
