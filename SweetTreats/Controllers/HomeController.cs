using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SweetTreats.Models;
using System.Threading.Tasks;
// using SweetTreats.ViewModels;

namespace SweetTreats.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}