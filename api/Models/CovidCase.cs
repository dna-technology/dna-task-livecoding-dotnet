using System.ComponentModel.DataAnnotations.Schema;
namespace dna.Models;

public class CovidCase {
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public Guid Id { get; set; }
  public string UserId { get; set; } = string.Empty;
}