using LoaningBank.DataPersistence;
using LoaningBank.Domain.Repositories;
using LoaningBank.DataPersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using LoaningBank.Services.Abstract;
using LoaningBank.Services;
using LoaningBank.WebAPI.Configuration;
using Mapster;
using MapsterMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LoaningBank.Web
{
    public class Startup
    {
        private readonly ConfigurationsManager ConfigurationsManager;

        public Startup(IConfiguration configuration)
        {
            ConfigurationsManager = new ConfigurationsManager(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("Default", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<RepositoryDbContext>(conf =>
                conf.UseLazyLoadingProxies().UseSqlServer(ConfigurationsManager.DatabaseConnectionString));

            services.AddScoped(_ => new BlobServiceClient(ConfigurationsManager.BlobStorageConnectionString));

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServicesConfiguration, ConfigurationsManager>();

            var mappingConfig = TypeAdapterConfig.GlobalSettings;
            mappingConfig.Scan(typeof(Services.Mapping.AssemblyReference).Assembly);
            services.AddSingleton(mappingConfig);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationsManager.AuthSecretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoaningBank v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("Default");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}