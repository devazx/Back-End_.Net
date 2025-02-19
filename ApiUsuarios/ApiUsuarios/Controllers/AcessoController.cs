using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : Controller
    {
        [HttpGet]
        [Authorize(Policy = "IdadeMinima")]
        public IActionResult Get()
        {
            return Ok("Acesso permitido!");
        }
    }
}
