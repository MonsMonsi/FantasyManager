using AutoMapper;
using FantasyManager.Application.Services;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Data;
using FantasyManager.Application.Config;
using FantasyManager.WPF.State.Navigators;
using FantasyManager.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FantasyManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            FootballContextFactory footballContextFactory = serviceProvider.GetRequiredService<FootballContextFactory>();
            IMapper mapper = serviceProvider.GetRequiredService<IMapper>();
            IUserService userService = serviceProvider.GetRequiredService<IUserService>();

            Window window = new MainWindow();
            window.DataContext = new MainViewModel(mapper); // TODO: just a workaround!! delete when possible!!!!
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<FootballContextFactory>();

            var mapper = AutoMapperConfig.ConfigureAutoMapper();
            services.AddSingleton(mapper);

            services.AddScoped<INavigator, Navigator>();

            services.AddSingleton<IUserService, UserService>();

            return services.BuildServiceProvider();
        }
    }
}
