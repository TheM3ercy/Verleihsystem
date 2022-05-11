using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Verleihsystem.Services;
using Verleihsystem.ViewModels;
using Verleihsystem.Windows;

namespace Verleisystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((ctx, services) => ConfigureServices(ctx.Configuration, services))
                .Build();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddTransient<BorrowProductViewModel>();
            services.AddTransient<EditAddCategoryViewModel>();
            services.AddTransient<EditAddCustomerViewModel>();
            services.AddTransient<EditAddProductViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<BorrowProduct>();
            services.AddTransient<EditAddCategory>();
            services.AddTransient<EditAddCustomer>();
            services.AddTransient<EditAddProduct>();
            services.AddSingleton<MainWindow>();

            services.AddSingleton<DbService>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using(host)
            {
                await host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
