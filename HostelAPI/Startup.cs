using Hostel.Business.Abstract;
using Hostel.Business.Concrete;
using Hostel.DataAccess.Abstract;
using Hostel.DataAccess.Concrete;

namespace HostelAPI
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
            services.AddSingleton<IHostelService, HostelManager>();
            services.AddSingleton<IHostelRepository, HostelRepository>();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "All Hostels Api";
                    doc.Info.Version = "1.0.13";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "yunus emre",
                        Url = "https://github.com/yemretekin"
                    };
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseOpenApi();
            app.UseSwaggerUI();
            app.UseRouting();


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}

