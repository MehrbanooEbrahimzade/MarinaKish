using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Application.Services.classes;
using Infrastructure.Repository.classes;
using Infrastructure.Repository.interfaces;
using Application.Services.interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Infrastructure;
using Infrastructure.Persist;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.ConfigureApplicationPersistence(Configuration);

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
            // AddScoped for users model(table)
            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRepository2, UserRepository2>();

            // AddScoped for Funs model(table)
            services.AddScoped<IFunService, FunService>();
            services.AddScoped<IFunRepository, FunRepository>();

            // AddScoped for schedules model(table)
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseAuthentication();
            //provider.MigrateDatabases();
        }
    }
}
