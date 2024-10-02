using Dadabase.data;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Xml.Linq;
using Testcontainers.PostgreSql;
using Xunit.Abstractions;

namespace Dadabase.Tests
{
    public class DadaBaseTest : IClassFixture<WebApplicationFactory<Program>>, IAsyncLifetime
    {
        private readonly WebApplicationFactory<Program> customWebAppFactory;
        private readonly PostgreSqlContainer  _dbContainer;
        private readonly ITestOutputHelper outputHelper;

        public DadaBaseTest(WebApplicationFactory<Program> webAppFactory, ITestOutputHelper outputHelper)
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


                builder.ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddProvider(new XUnitLoggerProvider(outputHelper));
                    logging.SetMinimumLevel(LogLevel.Information);
                });
            });

            _dbContainer = new PostgreSqlBuilder()
                .WithImage("postgres")
                .WithPassword("Strong_password_123!")
                .Build();
        }

        public async Task DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();

            var yourInitScriptContents = """"
                -- DROP SCHEMA dadabase;

                CREATE SCHEMA dadabase AUTHORIZATION dbf25_team_nam;

                -- DROP SEQUENCE dadabase.audience_id_seq;

                CREATE SEQUENCE dadabase.audience_id_seq
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;
                -- DROP SEQUENCE dadabase.audiencecategory_id_seq;

                CREATE SEQUENCE dadabase.audiencecategory_id_seq
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;
                -- DROP SEQUENCE dadabase.audiencecategory_id_seq1;

                CREATE SEQUENCE dadabase.audiencecategory_id_seq1
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;
                -- DROP SEQUENCE dadabase.categorizedaudience_id_seq;

                CREATE SEQUENCE dadabase.categorizedaudience_id_seq
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;
                -- DROP SEQUENCE dadabase.categorizedjoke_id_seq;

                CREATE SEQUENCE dadabase.categorizedjoke_id_seq
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;
                -- DROP SEQUENCE dadabase.deliveredjoke_id_seq;

                CREATE SEQUENCE dadabase.deliveredjoke_id_seq
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;
                -- DROP SEQUENCE dadabase.joke_id_seq;

                CREATE SEQUENCE dadabase.joke_id_seq
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;
                -- DROP SEQUENCE dadabase.jokecategory_id_seq;

                CREATE SEQUENCE dadabase.jokecategory_id_seq
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;
                -- DROP SEQUENCE dadabase.jokereactioncategory_id_seq;

                CREATE SEQUENCE dadabase.jokereactioncategory_id_seq
                	INCREMENT BY 1
                	MINVALUE 1
                	MAXVALUE 2147483647
                	START 1
                	CACHE 1
                	NO CYCLE;-- dadabase.audience definition

                -- Drop table

                -- DROP TABLE dadabase.audience;

                CREATE TABLE dadabase.audience (
                	id int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
                	audiencename varchar NULL,
                	description varchar NULL,
                	CONSTRAINT audience_pkey PRIMARY KEY (id)
                );


                -- dadabase.audiencecategory definition

                -- Drop table

                -- DROP TABLE dadabase.audiencecategory;

                CREATE TABLE dadabase.audiencecategory (
                	id int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
                	categoryname varchar NULL,
                	description varchar NULL,
                	CONSTRAINT audiencecategory_pkey PRIMARY KEY (id)
                );


                -- dadabase.joke definition

                -- Drop table

                -- DROP TABLE dadabase.joke;

                CREATE TABLE dadabase.joke (
                	id int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
                	jokename varchar NULL,
                	joketext varchar NULL,
                	CONSTRAINT joke_pkey PRIMARY KEY (id)
                );


                -- dadabase.jokecategory definition

                -- Drop table

                -- DROP TABLE dadabase.jokecategory;

                CREATE TABLE dadabase.jokecategory (
                	id int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
                	jokecategoryname varchar NULL,
                	descripion varchar NULL,
                	CONSTRAINT jokecategory_pkey PRIMARY KEY (id)
                );


                -- dadabase.jokereactioncategory definition

                -- Drop table

                -- DROP TABLE dadabase.jokereactioncategory;

                CREATE TABLE dadabase.jokereactioncategory (
                	id int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
                	recationlevel varchar NULL,
                	description varchar NULL,
                	CONSTRAINT jokereactioncategory_pkey PRIMARY KEY (id)
                );


                -- dadabase.categorizedaudience definition

                -- Drop table

                -- DROP TABLE dadabase.categorizedaudience;

                CREATE TABLE dadabase.categorizedaudience (
                	id int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
                	audienceid int4 NOT NULL,
                	audiencecategoryid int4 NOT NULL,
                	CONSTRAINT categorizedaudience_pkey PRIMARY KEY (id),
                	CONSTRAINT categorizedaudience_audiencecategoryid_fkey FOREIGN KEY (audiencecategoryid) REFERENCES dadabase.audiencecategory(id),
                	CONSTRAINT categorizedaudience_audienceid_fkey FOREIGN KEY (audienceid) REFERENCES dadabase.audience(id)
                );


                -- dadabase.categorizedjoke definition

                -- Drop table

                -- DROP TABLE dadabase.categorizedjoke;

                CREATE TABLE dadabase.categorizedjoke (
                	id int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
                	jokeid int4 NOT NULL,
                	jokecategoryid int4 NOT NULL,
                	CONSTRAINT categorizedjoke_pkey PRIMARY KEY (id),
                	CONSTRAINT categorizedjoke_jokecategoryid_fkey FOREIGN KEY (jokecategoryid) REFERENCES dadabase.jokecategory(id),
                	CONSTRAINT categorizedjoke_jokeid_fkey FOREIGN KEY (jokeid) REFERENCES dadabase.joke(id)
                );


                -- dadabase.deliveredjoke definition

                -- Drop table

                -- DROP TABLE dadabase.deliveredjoke;

                CREATE TABLE dadabase.deliveredjoke (
                	id int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
                	delivereddate date NOT NULL,
                	jokereactionid int4 NULL,
                	jokeid int4 NOT NULL,
                	audienceid int4 NOT NULL,
                	notes varchar NULL,
                	CONSTRAINT deliveredjokeid_pkey PRIMARY KEY (id),
                	CONSTRAINT deliveredjokeid_audienceid_fkey FOREIGN KEY (audienceid) REFERENCES dadabase.audience(id),
                	CONSTRAINT deliveredjokeid_jokeid_fkey FOREIGN KEY (jokeid) REFERENCES dadabase.joke(id),
                	CONSTRAINT deliveredjokeid_jokereactionid_fkey FOREIGN KEY (jokereactionid) REFERENCES dadabase.jokereactioncategory(id)
                );
                """";
            await _dbContainer.ExecScriptAsync(yourInitScriptContents);
        }

        [Fact]
        public async Task GetAllJokesTest()
        {
            var client = customWebAppFactory.CreateClient();
            var response = await client.GetFromJsonAsync<ICollection<Joke>>("/all");
            response.Count.Should().Be(4);
            
        }
    }
}
