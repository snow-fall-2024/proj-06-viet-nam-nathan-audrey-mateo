using Dadabase.data;
using Dadabase.Tests;
using FluentAssertions;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using Testcontainers.PostgreSql;
using Xunit.Abstractions;

public class IntegrationTestBase : DadaBaseTest,IClassFixture<WebApplicationFactory<Program>>, IAsyncLifetime
{
    private readonly WebApplicationFactory<Program> customWebAppFactory;
    private PostgreSqlContainer _dbContainer;

    public IntegrationTestBase(WebApplicationFactory<Program> webAppFactory, ITestOutputHelper outputHelper) :  base (webAppFactory, outputHelper)
    {
        customWebAppFactory = webAppFactory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<Dbf25TeamNamContext>();
                services.RemoveAll<DbContextOptions>();
                services.RemoveAll(typeof(DbContextOptions<Dbf25TeamNamContext>));
                services.AddDbContext<Dbf25TeamNamContext>(options =>
                    options.UseNpgsql(_dbContainer.GetConnectionString()));
            });

            _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres")
            .WithPassword("Strong_password_123!")
            .Build();

            builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddProvider(new XUnitLoggerProvider(outputHelper));
                logging.SetMinimumLevel(LogLevel.Information);
            });
        });
    }

    [Fact]
    public async Task GetData()
    {
        var client = customWebAppFactory.CreateClient();
        var response = await client.GetAsync("/all");
        response.Content.ToString().Length.Should().Be(4);
    }

    public Task DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public Task InitializeAsync()
    {
        throw new NotImplementedException();
    }
}