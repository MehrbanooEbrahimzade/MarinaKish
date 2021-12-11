using Marina_Club.Repository;
using Marina_Club.Repository.classes;
using Marina_Club.Repository.interfaces;
using Marina_Club.Services.classes;
using Marina_Club.Services.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddDbContext<DatabaseContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("DB"));
            });
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

            // AddScoped for Files model
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFileRepository, FileRepository>();

            // AddScoped for Messages model
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            // AddScoped for Conversations model
            services.AddScoped<IConversationService, ConversationService>();
            services.AddScoped<IConversationRepository, ConversationRepository>();

            // AddScoped for MarineCoinTransfers model
            services.AddScoped<IMarineCoinTransferRepository, MarineCoinTransferRepository>();
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
