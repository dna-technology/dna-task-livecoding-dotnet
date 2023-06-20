using Microsoft.EntityFrameworkCore;

namespace dna.Models;

public class CovidCaseContext : DbContext 
{
  public CovidCaseContext(DbContextOptions<CovidCaseContext> options) : base(options) {}

  public DbSet<CovidCase> CovidCases { get; set; } = null!;
}