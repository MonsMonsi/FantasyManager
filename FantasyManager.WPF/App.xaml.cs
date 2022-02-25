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
using FantasyManager.WPF.ViewModels.Factories.Interfaces;
using FantasyManager.WPF.ViewModels.Factories;

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

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            // DB-Context
            services.AddSingleton<FootballContextFactory>();

            var mapper = AutoMapperConfig.ConfigureAutoMapper();
            services.AddSingleton(mapper);

            services.AddScoped<INavigator, Navigator>();

            // Application-Services
            services.AddSingleton<IUserService, UserService>();

            // ViewModelFactories
            services.AddSingleton<IFantasyManagerViewModelAbstractFactory, FantasyManagerViewModelAbstractFactory>();
            services.AddSingleton<IFantasyManagerViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IFantasyManagerViewModelFactory<CreateTeamViewModel>, CreateTeamViewModelFactory>();
            services.AddSingleton<IFantasyManagerViewModelFactory<DraftTeamViewModel>, DraftTeamViewModelFactory>();
            services.AddSingleton<IFantasyManagerViewModelFactory<PlaySeasonViewModel>, PlaySeasonViewModelFactory>();

            // ViewModels
            services.AddScoped<MainViewModel>();

            // Windows
            services.AddScoped<MainWindow>(s => new WPF.MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
