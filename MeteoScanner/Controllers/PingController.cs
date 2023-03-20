﻿using Microsoft.AspNetCore.Mvc;

namespace MeteoScanner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}
