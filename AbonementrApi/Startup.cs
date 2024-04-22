using Api.DbInit;
using Data.Abonent;
using Microsoft.AspNetCore.HttpOverrides;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public virtual void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = ConfigureJsonSerializer();
                options.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IAbonentRepository, AbonentRepository>();

        Task.Run(async () => await DatabaseInitializer.InitializeAsync());
        
        services.AddSwaggerGen(x => { });

        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowAll",
                builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed(hostname => true);
                }
            );
        });

        services.AddMvc().AddNewtonsoftJson();
    }

    public virtual DefaultContractResolver ConfigureJsonSerializer()
    {
        return new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseCors("AllowAll");
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseForwardedHeaders(
            new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            }
        );

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapControllerRoute("default", "{controller=Account}/{action=Index}/{id?}");
        });
        ConfigureSwagger(app);
    }

    public virtual void ConfigureSwagger(IApplicationBuilder app)
    {
        // Configure the HTTP request pipeline
#if DEBUG
        app.UseDeveloperExceptionPage();
#endif
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
