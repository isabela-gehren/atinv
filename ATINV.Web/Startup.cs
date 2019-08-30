﻿using ATINV.Business;
using ATINV.Repository;
using ATINV.Web.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATINV.Web
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FundProfile());
                mc.AddProfile(new MovimentProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContextPool<AppDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("AtInvConnection")));

            services.AddTransient<IFundRepository, FundRepository>();
            services.AddTransient<IMovimentRepository, MovimentRepository>();
            services.AddTransient<IFundBusiness, FundBusiness>();
            services.AddTransient<IMovimentBusiness, MovimentBusiness>();
            services.AddTransient<DbContext, AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
