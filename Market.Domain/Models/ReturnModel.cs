using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Market.Domain.Models
{
    public class ReturnModel<TResult,TError>
    {
        public bool Succeed { get; set; }
        public TResult Data { get; set; }
        public TError Error { get; set; }
    }
}
