using Microsoft.EntityFrameworkCore;
using dna.Models;

public class CovidCaseRepositoryFixture : IDisposable
{
  public ICovidCaseRepository CovidCaseRepository { get; private set; }
  private CovidCaseContext CovidCaseContext { get; set; }

  public CovidCaseRepositoryFixture()
  {
    var options = new DbContextOptionsBuilder<CovidCaseContext>()
      .UseInMemoryDatabase("CovidCaseTestDatabase")
      .Options;

      CovidCaseContext = new CovidCaseContext(options);

      CovidCaseRepository = new CovidCaseRepository(CovidCaseContext);
  } 

  public void Dispose() {
    CovidCaseContext.Dispose();
  }
}