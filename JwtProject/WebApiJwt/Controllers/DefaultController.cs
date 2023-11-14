using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        
        [HttpGet("[Action]")]
        public IActionResult TokenOlustur()
        {
            return Ok(new CreateToken().TokenCreate());
        }
        [Authorize]
        [HttpGet("[Action]")]
        public IActionResult Test2()
        {
            return Ok("Hoşgelsdiniz");
        }

        
        [HttpGet("[Action]")]
        public IActionResult AdminTokenOlustur()
        {
            return Ok(new CreateToken().CreateTokenAdmin());
        }

        [Authorize(Roles ="Admin,Visitors")]
        [HttpGet("[Action]")]
        public IActionResult Test3()
        {
            return Ok("Token başarılı bir şekilde giriş yapıldı");
        }
    }
}
