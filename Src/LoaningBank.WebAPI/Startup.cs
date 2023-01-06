using LoaningBank.DataPersistence;
using LoaningBank.Domain.Repositories;
using LoaningBank.DataPersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using LoaningBank.Services.Abstract;
using LoaningBank.Services;
using LoaningBank.WebAPI.Configuration;
using Mapster;
using MapsterMapper;

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
                conf.UseLazyLoadingProxies().UseSqlServer(ConfigurationsManager.DbConnectionString));

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            var mappingConfig = TypeAdapterConfig.GlobalSettings;
            mappingConfig.Scan(typeof(Services.Mapping.AssemblyReference).Assembly);
            services.AddSingleton(mappingConfig);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}