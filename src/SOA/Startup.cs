using App;
using App.Interface;
using AppFundos;
using AppFundos.Interface;
using DayFw.DataAccess.Interfaces;
using Infra;
using Infra.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PI.Utility.App;
using PI.Utility.App.Interface;
using Proxy.AccessControl;
using Proxy.DriveAMnet;
using Proxy.DriveAMnet.Interface;
using Proxy.Icatu;
using Proxy.Icatu.Interface;
using Proxy.PortalInvestimentos;
using Proxy.PortalInvestimentos.Interface;
using Proxy.Sinacor;
using Proxy.Sinacor.Interface;
using Proxy.SisFinace;
using Proxy.SmartBrain;
using Proxy.SmartBrain.Interface;

namespace PI.Utility
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddControllers();

            //Repository
            services.AddScoped<IInfoBancRepository, InfoBancRepository>();
            services.AddScoped<IGestorFundosRepository, GestorFundosRepository>();
            services.AddScoped<IPortalInvestimentoRepository, PortalInvestimentosRepository>();
            services.AddScoped<IAccessControlRepository, AccessControlRepository>();
            services.AddScoped<IPortalInvestimentoQaRepository, PortalInvestimentosQaRepository>();


            //Parameters
            services.AddScoped<IConnectionParameters, DcvInvestimentoParameter>();
            services.AddScoped<IConnectionParameters, DcvPortalInvestimentosParameters>();
            services.AddScoped<IConnectionParameters, DcvPortalInvestimentosParametersQa>();
            services.AddScoped<IConnectionParameters, DcvInfobancParameter>();
            services.AddScoped<IConnectionParameters, AccessControlParameters>();

            //Application
            services.AddScoped<IAmbienteApp,AmbienteApp>();
            services.AddScoped<INegocioApp, NegocioApp>();
            services.AddScoped<IDesenvolvedorApp,DesenvolvedorApp>();
            services.AddScoped<IInfoBancApp, InfoBancApp>();
            services.AddScoped<IFundosApp, FundosApp>();
            services.AddScoped<IMonitorApp, MonitorApp>();
            services.AddScoped<IAccessControlApp, AccessControlApp>();
            services.AddScoped<IPiApp, PiApp>();
            services.AddScoped<IChangeApp, ChangeApp>();
            services.AddScoped<IWordDocumentApp, WordDocumentApp>();

            //Proxy
            services.AddScoped<IDriveAMnetProxy, DriveAMnetProxy>();
            services.AddScoped<ISinacorProxy,SinacorProxy>();
            services.AddScoped<IAccessControlProxy, AccessControlProxy>();
            services.AddScoped<ISmartBrainProxy, SmartBrainProxy>();
            services.AddScoped<ISisFinanceProxy, SisfinanceProxy>();
            services.AddScoped<IIcatuProxy, IcatuProxy>();
            services.AddScoped<IPortalInvestimentosProxy, PortalInvestimentosProxy>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200");
                                  });
            });

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Portal de Investimentos Utility",
                    Description = "Disponibilização de informações da Drive , Sinacor"
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

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Limpar Cache");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
