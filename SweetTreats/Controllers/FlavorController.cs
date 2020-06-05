using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using System;

namespace SweetTreats.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly SweetTreatsContext _db;

    public FlavorsController(SweetTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.ToList();
      return View(model)
    }
  }
}