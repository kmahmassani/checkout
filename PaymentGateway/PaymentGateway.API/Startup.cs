﻿using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using PaymentGateway.API.Filters;


namespace PaymentGateway.API
{
   public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;

        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _hostingEnv = env;
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvc()
                .AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter {
                        CamelCaseText = true
                    });
                })
                .AddXmlSerializerFormatters();


            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0.0", new Info
                    {
                        Version = "1.0.0",
                        Title = "Payment Gateway",
                        Description = "Payment Gateway (ASP.NET Core 2.0)",
                        Contact = new Contact()
                        {
                            Name = "Kamal Mahmassani",
                            Email = "kmahmassani@gmail.com"
                        },
                        TermsOfService = ""
                    });
                    c.CustomSchemaIds(type => type.FriendlyId());                    
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app
                .UseMvc()
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                    c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Payment Gateway");

                    //TODO: Or alternatively use the original Swagger contract that's included in the static files
                    //c.SwaggerEndpoint("/swagger/v1/openapi.json", "Payment Gateway Original");
                });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //TODO: Enable production exception handling (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling)
                // app.UseExceptionHandler("/Home/Error");
            }
        }
    }
}
