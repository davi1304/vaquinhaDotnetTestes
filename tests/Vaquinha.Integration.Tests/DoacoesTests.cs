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
    public class DoacoesTests
    {
        private readonly IntegrationTestsFixture<StartupWebTests> _integrationTestsFixture;

        public DoacoesTests(IntegrationTestsFixture<StartupWebTests> integrationTestsFixture)
        {
            _integrationTestsFixture = integrationTestsFixture;
        }

        [Trait("DoacoesControllerIntegrationTests", "DoacoesController_CarregarPaginaDoacao")]
        [Fact]
        public async Task DoacoesController_CarregarPaginaDoacao()
        {
            var doacoes = await _integrationTestsFixture.Client.GetAsync("Doacoes/Create");
            doacoes.EnsureSuccessStatusCode();
            doacoes.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}