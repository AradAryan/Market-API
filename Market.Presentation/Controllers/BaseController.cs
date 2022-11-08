﻿using Market.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Market.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        public ILogger<T> Logger { get; set; }

        public BaseController(ILogger<T> logger)
        {
            Logger = logger;
        }

    }
}
