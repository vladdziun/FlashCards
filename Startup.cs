﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LoginReg.Models;

namespace LoginReg
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
            services.AddDbContext<LoginRegContext>(options =>  options.UseMySql(Configuration["DBInfo:ConnectionString"]));
            services.AddSession();            
            services.AddMvc();

            services.AddAuthentication().AddGoogle(googleOptions =>  
            {  
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];  
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];  
            });

            services.AddAuthentication().AddFacebook(facebookOptions => 
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseStaticFiles();
            app.UseSession();  
            app.UseMvc();
        }
    }
}
