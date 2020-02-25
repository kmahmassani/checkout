using System;
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
using PaymentGateway.Domain.Interfaces;
using System.Data;
using Npgsql;
using PaymentGateway.DataAccess;
using PaymentGateway.DataAccess.Repositories;
using PaymentGateway.BusinessLogic;
using AutoMapper;
using PaymentGateway.API.Mappings;
using PaymentGateway.DataAccess.ApiClient;
using Swashbuckle.AspNetCore.Examples;

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
        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

           var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
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

                    c.OperationFilter<ExamplesOperationFilter>();
                });

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddTransient<IDbConnection>(db => new NpgsqlConnection(Configuration.GetConnectionString("PaymentsDB")));            
            services.AddTransient<IPaymentsRepository, PaymentsRepository>();
            services.AddTransient<IPaymentsBusinessLogic, PaymentsBusinessLogic>();            
            services.AddTransient<IBank>(x => new BankRepository(new BaseApiClient(new System.Net.Http.HttpClient(), Configuration.GetConnectionString("BankUrl"))));
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
                    c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Payment Gateway");
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
