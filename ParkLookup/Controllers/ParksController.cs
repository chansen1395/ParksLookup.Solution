using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkLookup.Models;
using System.Linq;
using System;


    // public int ParkId { get; set; }
    // public string User { get; set; }
    // public string ParkName { get; set; }
    // public string State { get; set; }
    // public string City { get; set; }
    // public string Activities { get; set; }
    // public int Rating { get; set; }
namespace ParkLookup.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkLookupContext _db;

    public ParksController(ParkLookupContext db)
    {
      _db = db;
    }

    // GET: api/Parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string user, string parkName, string state, string city, string activities, int rating)
    {
      var query = _db.Parks.AsQueryable();
      if (user != null)
      {
        query = query.Where(entry => entry.User == user);
      }
      if (state != null)
      {
        query = query.Where(entry => entry.ParkName == parkName);
      }
      if (parkName != null)
      {
        query = query.Where(entry => entry.State == state);
      }
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      } 
      if (activities != null)
      {
        query = query.Where(entry => entry.Activities == activities);
      } 
      if (rating > 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      } 
      return await query.ToListAsync();
    }

    // GET: api/Parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        var Park = await _db.Parks.FindAsync(id);

        if (Park == null)
        {
            return NotFound();
        }

    return Park;
    }

    // POST api/Parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park Park)
    {
      _db.Parks.Add(Park);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPark), new { id = Park.ParkId }, Park);
    }

    // PUT: api/Parks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park Park)
    {
      if (id != Park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(Park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // PATCH: api/Parks/5
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, Park Park)
    {
      if (id != Park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(Park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/Parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var Park = await _db.Parks.FindAsync(id);
      if (Park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(Park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }


  }
}