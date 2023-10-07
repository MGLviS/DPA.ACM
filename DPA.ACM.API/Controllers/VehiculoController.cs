using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    public class VehiculoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
