using Microsoft.AspNetCore.Mvc;
using SweetTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetTreats.Controllers
{
  [Authorize]
  public class PatronsController : Controller
  {
    private readonly SweetTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public PatronsController(UserManager<ApplicationUser> userManager, SweetTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userPatron = _db.Patrons.Where(entry => entry.User.Id == currentUser.Id);
      return View(userPatron);
    }

    public ActionResult Create()
    {
      ViewBag.PatronId = new SelectList(_db.Patrons, "PatronId", "PatronName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Patron patron, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      patron.User = currentUser;
      _db.Patrons.Add(patron);
      if (FlavorId != 0)
      {
        _db.Checkout.Add(new Checkout() { PatronId = patron.PatronId, FlavorId = FlavorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  public ActionResult Details(int id)
    {
      var thisPatron = _db.Patrons
          .Include(patron => patron.Flavors)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }

    public ActionResult Edit(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisPatron);
    }

    [HttpPost]
    public ActionResult Edit(Patron patron, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.Checkout.Add(new Checkout() { FlavorId = FlavorId, PatronId = patron.PatronId });
      }
      _db.Entry(patron).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisPatron);
    }

    [HttpPost]
    public ActionResult AddFlavor(Flavor flavor, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.Checkout.Add(new Checkout() { FlavorId = FlavorId, PatronId = flavor.PatronId });
        
        var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == FlavorId);
        // thisFlavor.Quantity -=1;
        _db.Entry(thisFlavor).State = EntityState.Modified;
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      return View(thisPatron);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      _db.Patrons.Remove(thisPatron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.Checkout.FirstOrDefault(entry => entry.CheckoutId == joinId);
      var flavorId = joinEntry.FlavorId;
      var thisTitle = _db.Flavors.FirstOrDefault(titles => titles.FlavorId == flavorId);
      // thisTitle.Quantity +=1;
      _db.Checkout.Remove(joinEntry);
      _db.Entry(thisTitle).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}