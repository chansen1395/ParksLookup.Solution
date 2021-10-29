using Microsoft.EntityFrameworkCore;

namespace TravelAPI.Models
{
    public class TravelAPIContext : DbContext
    {
      public TravelAPIContext(DbContextOptions<TravelAPIContext> options)
          : base(options)
      {
      }

      public DbSet<Park> Parks { get; set; }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Park>()
        .HasData
        (
          new Park { ParkId = 1, User = "Bob", ParkName = "Champoeg", State = "Oregon", City = "St. Paul", Rating = 4, Activities = "Camping, Hiking, Fishing, Biking, Museum" },
          new Park { ParkId = 2, User = "Jerry", ParkName = "Yellowstone", State = "Montana", City = "Bozeman", Rating = 5, Activities = "Camping, Hiking, Rafting, Biking, Wildlife" },
          new Park { ParkId = 3, User = "Elizabeth", ParkName = "Multnomah Falls", State = "Oregon", City = "Troutdale", Rating = 5, Activities = "Camping, Hiking, Waterfall, Museum, Food" },
          new Park { ParkId = 4, User = "Elizabeth", ParkName = "Oregon Sunstone Mine", State = "Oregon", City = "Plush", Rating = 4, Activities = "Camping, Mining, Hunting" },
          new Park { ParkId = 5, User = "Joe", ParkName = "Fort Clatsop", State = "Oregon", City = "Astoria", Rating = 3, Activities = "Camping, Museum" },
          new Park { ParkId = 5, User = "Joe", ParkName = "Rocky Mountain National Park", State = "Colorado", City = "Estes Park", Rating = 3, Activities = "Camping, Hiking, Waterfall, River" },
          new Park { ParkId = 6, User = "Henrietta", ParkName = "Tillamook State Forest", State = "Oregon", City = "Tillamook", Rating = 3, Activities = "Camping, Hiking, Waterfall, River, Fishing, Hunting" }
        );
      }
    }
}

    // public int ParkId { get; set; }
    // public string User { get; set; }
    // public string ParkName { get; set; }
    // public string State { get; set; }
    // public string City { get; set; }
    // public string Activities { get; set; }
    // public int Rating { get; set; }