using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAPI.Models;
using System.Linq;
using System;
// using TravelAPI.DAL;
using TravelAPI.ViewModels;
// using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    public class HomeController : Controller
    {
    // ABOUT
    // private TravelAPIContext db = new TravelAPIContext();
    private readonly TravelAPIContext _db;

    public HomeController(TravelAPIContext db)
    {
      _db = db;
    }
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      // Attempt to add index
      [HttpGet("/Sort")]
      public ViewResult Sort(string sortOrder, string searchString)
      {
        ViewBag.RatingSortParm = String.IsNullOrEmpty(sortOrder) ? "rating_desc" : "";
        ViewBag.StateSortParm = sortOrder == "State" ? "state_desc" : "State";
        var parks = from s in _db.Parks
                      select s;
        
        if (!String.IsNullOrEmpty(searchString))
        {
          parks = parks.Where(s => s.State.Contains(searchString)
          || s.City.Contains(searchString));
        }
        switch (sortOrder)
        {
          case "rating_desc":
            parks = parks.OrderByDescending(s => s.Rating);
            break;
          case "State":
            parks = parks.OrderBy(s => s.State);
            break;
          case "state_desc":
            parks = parks.OrderByDescending(s => s.State);
            break;
          default:
            parks = parks.OrderBy(s => s.Rating);
            break;
          }
        foreach(Park park in parks)
        {
           System.Console.WriteLine("Test toList: " + park.State);
        
        
        }
        // return View();
        // return View(parks);
        return View(parks.ToList());
      }

      [HttpGet("/About")]
      public ActionResult About()
      {
        IQueryable<RatingCountGroup> data = from park in _db.Parks
        group park by park.City into ratingGroup orderby ratingGroup.Count() descending
        select new RatingCountGroup()
        {
            City = ratingGroup.Key,
            RatingCount = ratingGroup.Count()
        };

          return View(data.ToList());
      }

    }
}