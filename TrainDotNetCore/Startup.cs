using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrainDotNetCore.Services;

namespace TrainDotNetCore
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
            //services.AddDbContext<EmployeeContext>(opt => opt.UseInMemoryDatabase("EmployeeList"));
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IHeroService, HeroService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builde => builde.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            // TODO : need to install package with command $ Install-Package Serilog.Extensions.Logging.File -Version 1.1.0
            //loggerFactory.AddFile("C:\\Users\\SSG\\Desktop\\logger.log");

            // TODO : Install-Package Microsoft.Extensions.Logging.Log4Net.AspNetCore -Version 2.2.10
            //loggerFactory.AddLog4Net(Configuration.GetValue<string>("Log4NetConfigFile:Name"));
            loggerFactory.AddLog4Net("C:\\Users\\SSG\\source\\repos\\TrainDotNetCore\\TrainDotNetCore\\log4net.config");
            loggerFactory.AddEventSourceLogger();

            // TODO : Add Authentication for JWT
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin");
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
