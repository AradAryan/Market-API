﻿using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class ProductOption : BaseModel
    {
        public string? Name { get; set; }
        public Guid OptionId { get; set; }
    }
}
