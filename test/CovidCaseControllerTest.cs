namespace test;
using dna.Models;
using dna.Controllers;

public class CovidCaseControllerTest : IClassFixture<CovidCaseRepositoryFixture>
{
    CovidCaseRepositoryFixture fixture;

    public CovidCaseControllerTest(CovidCaseRepositoryFixture fixture) {
        this.fixture = fixture;
    }

    [Fact]
    public async void shouldAddCase()
    {
        // given
        // when
        var casePayload = new CovidCaseDTO {
            UserId = "0720f0d6-0e82-4be5-98f0-72c2c9f229a6"
        };

        var controller = new CovidCasesController(fixture.CovidCaseRepository);

        await controller.PostCovidCase(casePayload);

        // then
        var cases = await fixture.CovidCaseRepository.GetAll();

        Assert.NotNull(cases);
        Assert.Single(cases);
    }
}