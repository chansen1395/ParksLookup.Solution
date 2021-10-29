using System.ComponentModel.DataAnnotations;


namespace ParkLookup.Models
{
  public class Park
  {
    public int ParkId { get; set; }

    [Required]
    [StringLength(20)]
    public string User { get; set; }

    [Required]
    [StringLength(50)]
    public string State { get; set; }

    [Required]
    [StringLength(50)]
    public string City { get; set; }

    [Required]
    [StringLength(50)]
    public string ParkName { get; set; }

    [Required]
    [StringLength(500)]
    public string Activities { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Please enter a rating between 1 - 5")]
    public int Rating { get; set; }
    

  }
  
}

    // public int ParkId { get; set; }
    // public string User { get; set; }
    // public string ParkName { get; set; }
    // public string Country { get; set; }
    // public string City { get; set; }
    // public string Activities { get; set; }
    // public int Rating { get; set; }



// look up random Park