using Microsoft.AspNetCore.Mvc;

namespace Doctores_Pacientes.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
