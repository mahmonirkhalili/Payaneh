

using IApplication.Interfaces;
using IApplication.Services;
using IApplication.Services.UsersServices;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System.Formats.Asn1;
using System.Windows.Forms;

namespace EndPoint.WinApp
{
    internal static class Program
    {
        public static IServiceProvider serviceProvider { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();



            var services = new ServiceCollection();
            ConfigureServices(services);


            Application.Run(new Forms.FrmMain());
        }

        static void ConfigureServices(ServiceCollection services)
        {
            // services.AddScoped<Home>();
            services.AddDbContext<DataBaseContext>();
            services.AddScoped<IUsers, UsersClass>().AddTransient<IDataBaseContext, DataBaseContext>()

                .AddScoped<IInvoice, InvoiceService>();
            serviceProvider = services.BuildServiceProvider();
        }
    }
}