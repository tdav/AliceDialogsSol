using Alice.Dialogs.Anegdots.Repository;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;

namespace Alice.Dialogs.Anegdots
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conf = builder.Configuration;

            builder.Host.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext());

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMyAliceService();

            builder.Services.AddMemoryCache();
            builder.Services.AddResponseCompression();


            var app = builder.Build();



            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });

            app.MapControllers();
            app.UseResponseCompression();
            app.UseSerilogRequestLogging();

            app.Run();
        }
    }
}