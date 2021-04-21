using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Pages;

namespace Web.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index() => Redirect("/");

        [Authorize]
        public IActionResult Devices() => Redirect("/devices");

        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}