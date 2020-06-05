using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using SweetTreats.Models;
using System;

namespace SweetTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly SweetTreatsContext _db;

    public TreatsController(SweetTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Treat treat, int FlavorId)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      Treat foundTreat _db.Treats.FirstOrDefault(t=>(t.Name == treat.Name));
      .db.FlavorTreat.Add(new FlavorTreat() {FlavorId = FlavorId, TreatId = foundTreat.TreatId});
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}