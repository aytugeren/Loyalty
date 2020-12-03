using AutoMapper;
using Loyalty.Business.AddressServiceFolder;
using Loyalty.Business.AutoMapperProfile;
using Loyalty.Business.CustomerServiceFolder;
using Loyalty.Business.CustomerStoreServiceFolder;
using Loyalty.Business.OwnerServiceFolder;
using Loyalty.Business.StoreServiceFolder;
using Loyalty.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.Web
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

            MapperConfiguration config = LoyaltyProfile.Configuration();

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddTransient<LoyaltyDbContext>();
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(LoyaltyProfile));
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthenticationOwnerService, AuthenticationOwnerService>();
            services.AddTransient<ICustomerStoreService, CustomerStoreService>();
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
