using FluentAssertions;
using System.Threading.Tasks;
using Vaquinha.Domain;
using Vaquinha.Domain.Extensions;
using Vaquinha.Integration.Tests.Fixtures;
using Vaquinha.MVC;
using Xunit;

namespace Vaquinha.Integration.Tests
{
    [Collection(nameof(IntegrationWebTestsFixtureCollection))]
    public class DoadoresTests
    {
        private readonly IDoacaoService _doacaoService;
        private readonly IntegrationTestsFixture<StartupWebTests> _integrationTestsFixture;

        public DoadoresTests(IntegrationTestsFixture<StartupWebTests> integrationTestsFixture)
        {
            _integrationTestsFixture = integrationTestsFixture;
        }

        [Trait("DoadoresControllerIntegrationTests", "DoadoresController_CarregarPaginaInicial_TotalDoadoresETotalValorArrecadadoDeveSerZero")]
        [Fact]
        public async Task HomeController_CarregarPaginaInicial_TotalDoadoresETotalValorArrecadadoDeveSerZero()
        {
            // Arrange & Act
            var home = await _integrationTestsFixture.Client.GetAsync("Home");

            // Assert
            home.EnsureSuccessStatusCode();
            var dadosHome = await home.Content.ReadAsStringAsync();

            var totalArrecadado = _doacaoService.RecuperarDoadoresAsync();
            var metaCampanha = _integrationTestsFixture.ConfiguracaoGeralAplicacao.MetaCampanha.ToDinheiroBrString();

            // Dados totais da doação
            dadosHome.Should().Contain(expected: "Arrecadamos quanto?");
            dadosHome.Should().Contain(expected: totalArrecadado);

            dadosHome.Should().Contain(expected: "Quanto falta arrecadar?");
            dadosHome.Should().Contain(expected: metaCampanha);
        }
    }
}