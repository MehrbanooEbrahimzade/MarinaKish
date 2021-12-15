using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Application.Services.classes;
using Infrastructure.Repository;
using Infrastructure.Repository.classes;
using Infrastructure.Repository.interfaces;
using Application.Services.interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Infrastructure;

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
            //from DependencyInjectionPersist
            services.ConfigureApplicationPersistence(Configuration);

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
            // AddScoped for users model(table)
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

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

            // AddScoped for File model
            //services.AddScoped<IFileService, FileService>();
            //services.AddScoped<IFileRepository, FileRepository>();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            provider.MigrateDatabases();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
