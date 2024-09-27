using Spotify.Application.Common.MappingProfile;
using Spotify.Application.DIContainer;
using Spotify.Application.Repositories.RepositoriesDBContext;
using Spotify.Database.Repositories.Interfaces;
using Spotify.Persistense.DIContainer;
using System.Reflection;
using Spotify.Application.Repositories.RepositoriesGroup;

namespace Spotify.WebAPI
{
    public class Startup(IConfiguration configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IRepositoryGroupCRUD).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(configuration);
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
