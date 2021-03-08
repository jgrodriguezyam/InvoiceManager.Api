using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using InvoiceManager.Services.Interfaces;
using InvoiceManager.Services.Implements;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.EntityFrameworkCore.DataBase;
using Microsoft.EntityFrameworkCore;
using InvoiceManager.EntityFrameworkCore.Repositories;
using InvoiceManager.Infrastructure.Configs;
using Microsoft.OpenApi.Models;
using InvoiceManager.Mapper.Configs;
using InvoiceManager.Api.Filters;

namespace InvoiceManager.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(mapper => mapper.AddProfile<AutoMapping>(), typeof(Startup));

            services.AddDbContext<InvoiceManagerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("InvoiceManagerConnection"));
            });

            services.AddControllers()
                    .AddNewtonsoftJson();

            services.AddTransient<ActionFilterAttribute>();

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "InvoiceManager Api", Version = "v1" });
            });

            AddServices(services);

            AddRepositories(services);

            AddDBConfig(services);

            AddVersion(services);
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
        }

        private void AddDBConfig(IServiceCollection services)
        {
            services.AddScoped<IDataBaseTransaction, DataBaseTransaction>();          
        }

        private void AddVersion(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InvoiceManagerContext invoiceManagerContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            invoiceManagerContext.Database.Migrate();

            SwaggerOptions(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SwaggerOptions(IApplicationBuilder app)
        {
            var swaggerOptions = new SwaggerOptions();

            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options => {
                options.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });
        }
    }
}
