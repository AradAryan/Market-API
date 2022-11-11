using Market.Domain;
using Market.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<ProductController>
    {
        private ApplicationContext Context { get; set; }
        public ProductController(ILogger<ProductController> logger, ApplicationContext context) : base(logger)
        {
            Context = context;
        }


    }
}
