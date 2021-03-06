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

      // Sorts/filters results on certain parameters
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

      // POST api/Parks
      [HttpPost("/About")]
      public async Task<ActionResult<Park>> Post(Park park)
      {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();

        return RedirectToAction("About");
      }

      [HttpGet("/Details/{id}")]
      public IActionResult Details(int id)
      {
        var thispark = _db.Parks.FirstOrDefault(park => park.ParkId == id);
          
          return View(thispark);
      }

      // [HttpGet("/Edit/{id}")]
      // public ActionResult Edit(int id)
      // {
      //   var thisPark = _db.Parks.FirstOrDefault(park => park.ParkId == id);
      //   return View(thisPark);
      // }

      // [HttpPost("/Edit/{id}")]
      // public ActionResult Edit(Park park)
      // {
      //   _db.Entry(park).State = EntityState.Modified;
      //   _db.SaveChanges();
      //   return RedirectToAction("Sort");
      // }

      // // DELETE: api/Parks/5
      // [ActionName("Delete")]
      // public ActionResult Delete(int id)
      // {
      //   var park = _db.Parks.Find(id);
      //   if (park == null)
      //   {
      //     return NotFound();
      //   }

      //   _db.Parks.Remove(park);
      //   _db.SaveChanges();

      //   return RedirectToAction("Sort");
      // }
    }
}