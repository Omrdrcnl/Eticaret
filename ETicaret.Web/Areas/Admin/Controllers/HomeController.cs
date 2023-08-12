using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

namespace ETicaret.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rol()
        {
            return View();
        }
    }
}

