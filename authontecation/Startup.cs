using authontecation.Authontecation;
using authontecation.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using repo.interfces;
using repo.Mapper;
using repo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace authontecation
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "authontecation", Version = "v1" });
            });

            //EF
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("AppCon")));

            //Identity

            services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.AddScoped<IEmployee,EmployeeRepo>();

            //authontecation

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });


       //     services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       //.AddJwtBearer(options =>
       //{
       //    var keybytes = Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]);
       //    var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keybytes);
       //    options.TokenValidationParameters = new TokenValidationParameters
       //    {
       //        IssuerSigningKey = signingKey,
       //        ValidateIssuer = true,
       //        ValidateAudience = true,
       //        ValidateLifetime = true,
       //        ValidateIssuerSigningKey = true,
       //        ValidIssuer = Configuration["Jwt:ValidIssuer"],
       //        ValidAudience = Configuration["Jwt:ValidAudience"]

       //    };
       //});

            //mail
            //services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            //services.AddTransient<IMailService, MailServiceRepo>();

            //automapper
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .WithOrigins("http://localhost:4200");
            }));
            services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<ISupplierRepo, SupplierRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IOperationRepo, OperationRepo>();
            services.AddScoped<IShokakOperationRepo, ShokakOperationRepo>();
            services.AddScoped<IBuyOrderRepo, BuyOrderRepo>();
            services.AddScoped<IBuyOperationRepo, BuyOperationRepo>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "authontecation v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {

                    
                    await context.Response.WriteAsync("Token Validation Has Failed. Request Access Denied");
                }
            });
            app.UseAuthentication();
            app.UseAuthorization();

            
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
