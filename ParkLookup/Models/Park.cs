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