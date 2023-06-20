using Microsoft.AspNetCore.Mvc;
using dna.Models;

namespace dna.Controllers;

[ApiController]
[Route("cases")]
public class CovidCasesController : ControllerBase
{
  private readonly ICovidCaseRepository _covidCaseRepository;

  public CovidCasesController(ICovidCaseRepository covidCaseRepository) {
    _covidCaseRepository = covidCaseRepository;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<CovidCase>>> GetCovidCases()
  {
    var cases = await _covidCaseRepository.GetAll();
    return Ok(cases.Select(c => CaseToDTO(c)).ToList());
  }

  [HttpPost]
  public async Task<ActionResult<CovidCase>> PostCovidCase(CovidCaseDTO caseDTO)
  {
    var covidCase = new CovidCase
    {
      UserId = caseDTO.UserId
    };

    var savedCase = await _covidCaseRepository.Add(covidCase);

    return Ok(CaseToDTO(savedCase));
  }

  private static CovidCaseDTO CaseToDTO(CovidCase covidCase) =>
    new CovidCaseDTO {
      Id = covidCase.Id,
      UserId = covidCase.UserId,
    };
}