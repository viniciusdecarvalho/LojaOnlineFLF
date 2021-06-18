using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LojaOnlineFLF.AuthAPI.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController: ControllerBase
    {
        public LoginController()
        {
        }

        [HttpPost]
        public IActionResult Token()
        {
            return Ok();
        }
    }
}
