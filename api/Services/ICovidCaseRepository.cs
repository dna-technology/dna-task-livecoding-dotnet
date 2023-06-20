using dna.Models;

public interface ICovidCaseRepository {
  Task<IEnumerable<CovidCase>> GetAll();
  Task<CovidCase> Add(CovidCase covidCase);
}