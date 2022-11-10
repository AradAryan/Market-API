using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Market.Domain.Models
{
    public class ResponseModel
    {
        public bool Succeed { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }
    }
}
