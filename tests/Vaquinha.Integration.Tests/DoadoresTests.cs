using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Vaquinha.Domain.Extensions;
using Vaquinha.Integration.Tests.Fixtures;
using Vaquinha.MVC;
using Xunit;

namespace Vaquinha.Integration.Tests
{
    [Collection(nameof(IntegrationWebTestsFixtureCollection))]
    public class DoadoresTests
    {
        private readonly IntegrationTestsFixture<StartupWebTests> _integrationTestsFixture;

        public DoadoresTests(IntegrationTestsFixture<StartupWebTests> integrationTestsFixture)
        {
            _integrationTestsFixture = integrationTestsFixture;
        }

        [Trait("DoadoresControllerIntegrationTests", "DoadoresController_CarregarPaginaDoadores")]
        [Fact]
        public async Task DoadoresController_CarregarPaginaDoadores()
        {
            var doadores = await _integrationTestsFixture.Client.GetAsync("Doadores");
            doadores.EnsureSuccessStatusCode();
            doadores.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}