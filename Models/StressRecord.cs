using System.ComponentModel.DataAnnotations;

namespace DataMash.API.Models
{
   public class StressRecord
{
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }
    public int Stress { get; set; }
    public string? Emotion { get; set; }
    public string? Note { get; set; }
}

}
