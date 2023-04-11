using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRepository.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRepository.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected IActionResult ErrorHadling(Exception ex)
        {
            if (ex is UnauthorizedException)
                return Unauthorized(ex.Message);
            if (ex is NotFoundException)
                return NotFound(ex.Message);
            else
                return BadRequest("An Unexpected Error Occurred");
        }

    }
}

