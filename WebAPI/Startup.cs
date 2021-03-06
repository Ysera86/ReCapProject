using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Business. Manage NuGet pckgs > Autofac ve Autofac.Extras.DynamicProxy indir
            //..>>> Business.DependencyResolvers.Autofac . Autofac.Module'den t�ret class ve override Load
            // sonra da bu porje.Program.cs i�inde .NetCore snn IoC container�n� de�il Autofac'inkini kullan�cam (�nk onda AOP de var) de
            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IBrandDAL, EfBrandDAL>();
            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<ICarDAL, EfCarDAL>();
            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IColorDAL, EfColorDAL>();
            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<ICustomerDAL, EfCustomerDAL>();
            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDAL, EfUserDAL>();
            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<IRentalDAL, EfRentalDAL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
