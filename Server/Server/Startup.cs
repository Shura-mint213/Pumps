using Database;
using Microsoft.EntityFrameworkCore;
using Server.Services;
using Shared.Statics;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddDbContext<PumpsContext>(options =>                
                options.UseSqlServer(Settings.ConnectionString));
            //builder.Services.AddDbContext<DatabaseContext>(options =>
            //    options.UseNpgsql(builder.Configuration["ConnectionStrings"]));

            services.AddRepositories();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
        }        
    }
}
