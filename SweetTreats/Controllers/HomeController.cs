using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SweetTreats.Models;
using System.Threading.Tasks;


namespace SweetTreats.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}