using AutoMapper;
using FantasyManager.Data;
using FantasyManager.WPF.Config;
using FantasyManager.WPF.Services;
using FantasyManager.WPF.Services.Interfaces;
using FantasyManager.WPF.State.Navigators;
using FantasyManager.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FantasyManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
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
