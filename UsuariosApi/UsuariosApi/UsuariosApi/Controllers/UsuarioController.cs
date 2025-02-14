using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
