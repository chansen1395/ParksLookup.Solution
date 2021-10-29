using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkLookup.Models;
using System.Linq;
using System;
// using ParkLookup.DAL;
using ParkLookup.ViewModels;
// using Microsoft.AspNetCore.Mvc;

namespace ParkLookup.Controllers
{
    public class HomeController : Controller
    {
    // ABOUT
    // private ParkLookupContext db = new ParkLookupContext();
    private readonly ParkLookupContext _db;

    public HomeController(ParkLookupContext db)
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
        ViewBag.ParkNameSortParm = sortOrder == "ParkName" ? "parkname_desc" : "ParkName";
        var parks = from s in _db.Parks
                      select s;
        
        if (!String.IsNullOrEmpty(searchString))
        {
          parks = parks.Where(s => s.ParkName.Contains(searchString)
          || s.City.Contains(searchString));
        }
        switch (sortOrder)
        {
          case "rating_desc":
            parks = parks.OrderByDescending(s => s.Rating);
            break;
          case "ParkName":
            parks = parks.OrderBy(s => s.ParkName);
            break;
          case "state_desc":
            parks = parks.OrderByDescending(s => s.ParkName);
            break;
          default:
            parks = parks.OrderBy(s => s.Rating);
            break;
          }
        foreach(Park park in parks)
        {
           System.Console.WriteLine("Test toList: " + park.ParkName);
        
        
        }
        // return View();
        // return View(parks);
        return View(parks.ToList());
      }

      [HttpGet("/About")]
      public ActionResult About()
      {
        IQueryable<RatingCountGroup> data = from park in _db.Parks
        group park by park.ParkName into ratingGroup orderby ratingGroup.Count() descending
        select new RatingCountGroup()
        {
            ParkName = ratingGroup.Key,
            RatingCount = ratingGroup.Count()
        };

          return View(data.ToList());
      }

    }
}