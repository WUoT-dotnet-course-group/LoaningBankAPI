using LoaningBank.DataPersistence;
using LoaningBank.Domain.Repositories;
using LoaningBank.DataPersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using LoaningBank.Services.Abstract;
using LoaningBank.Services;
using LoaningBank.WebAPI.Configuration;

namespace LoaningBank.Web
{
    public class Startup
    {
        private readonly ConfigurationsManager ConfigurationManager;

        public Startup(IConfiguration configuration)
        {
            ConfigurationManager = new ConfigurationsManager(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RepositoryDbContext>(conf =>
                conf.UseSqlServer(ConfigurationManager.DbConnectionString));

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}