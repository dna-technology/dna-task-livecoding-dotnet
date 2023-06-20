using Microsoft.EntityFrameworkCore;
using dna.Models;

public class CovidCaseRepository : ICovidCaseRepository
{
  protected readonly CovidCaseContext _context;

  public CovidCaseRepository(CovidCaseContext context) {
    _context = context;
  }

  public async Task<CovidCase> Add(CovidCase covidCase)
  {
    await _context.CovidCases.AddAsync(covidCase);
    await _context.SaveChangesAsync();

    return covidCase;
  }

  public async Task<IEnumerable<CovidCase>> GetAll()
  {
    return await _context.CovidCases.ToListAsync();
  }
}