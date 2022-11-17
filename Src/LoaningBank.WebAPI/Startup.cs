using LoaningBank.DataPersistence;
using LoaningBank.Domain.Repositories;
using LoaningBank.DataPersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using LoaningBank.Services.Abstract;
using LoaningBank.Services;
using ConfigurationManager = LoaningBank.WebAPI.Configuration.ConfigurationManager;

namespace LoaningBank.Web
{
    public class Startup
    {
        private readonly ConfigurationManager _configManager;

        public Startup(IConfiguration configuration)
        {
            _configManager = new ConfigurationManager(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RepositoryDbContext>(conf =>
                conf.UseSqlServer(_configManager.DbConnectionString));

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