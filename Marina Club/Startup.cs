using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Application.Services.classes;
using Application.Services.interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Infrastructure;
using Infrastructure.Persist;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.RepasitoryInterfaces;
using Infrastructure.Helper;
using Infrastructure.Repository.classes;
using Infrastructure.Repository.Classes;
using Domain.IConfiguration;
using Marina_Club.Activator.MiddleWare;
using Microsoft.Extensions.Logging;
using Marina_Club.Activator.Middleware;
using CastleWindsor;
using Castle.Windsor.MsDependencyInjection;

namespace Marina_Club
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            ConfigureMvc(services);
            services.ConfigureApplicationPersistence(Configuration);

            Installer.Install(services);


            JwtConfiguration(services);
            ConfigureIdentity(services);
            ConfigureCors(services);

            services.AddOptions();
            

            services.AddAuthorization();

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<ApplicationLogs>>();
            services.AddSingleton(typeof(ILogger), logger);

            ConfigureDependency(services);

            return WindsorRegistrationHelper.CreateServiceProvider(Installer.Container, services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseMvc();
            app.UseAuthentication();
            app.UseMiddleware<ErrorHandlerMiddleWare>();
            app.UseCors("Policy");
            //provider.MigrateDatabases();
        }
        private void ConfigureMvc(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {

                options.SerializerSettings.Converters.Add(new JsonDateTimeConvertor());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        public void ConfigureDependency(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // AddScoped for users model(table)
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            // AddScoped for Fun model(table)
            services.AddTransient<IFunService, FunService>();
            services.AddTransient<IFunRepository, FunRepository>();

            // AddScoped for schedules model(table)
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();

            // AddScoped for scheduleInformation model(table)
            services.AddTransient<IScheduleInfoService, ScheduleInfoService>();
            services.AddTransient<IScheduleInfoRepository, ScheduleInfoRepository>();

            // AddScoped for Tickets model
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            // AddScoped for Comments model
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            //AddScoped for MyFile model
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFileRepository, FileRepository>();

            // AddScoped for Messages model
            services.AddScoped<IMessageService, MessageService>();
            //services.AddScoped<IMessageRepository, MessageRepository>();

            // AddScoped for Conversations model
            services.AddScoped<IConversationService, ConversationService>();
            //services.AddScoped<IConversationRepository, ConversationRepository>();

            // AddScoped for MarineCoinTransfers model
            //services.AddScoped<IMarineCoinTransferRepository, MarineCoinTransferRepository>();
            services.AddScoped<IMarineCoinTransferService, MarineCoinTransferService>();

            // AddScoped for Sellers model
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<ISellerService, SellerService>();

            // AddScoped for ContactUs model
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();
        }
        private void JwtConfiguration(IServiceCollection services)
        {
            services.Configure<JwtToken>(Configuration.GetSection("Jwt"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

        }
        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 11;
                options.Password.RequiredUniqueChars = 0;
            });
        }
        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(s => s.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowAnyOrigin();
            }));
        }
    }
}
