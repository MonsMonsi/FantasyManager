using AutoMapper;
using FantasyManager.Data;
using FantasyManager.Application.MapperConfig;
using FantasyManager.WPF.State.Navigators;
using FantasyManager.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;
using FantasyManager.WPF.ViewModels.Factories;
using FantasyManager.Domain.Services.AuthenticationServices;
using FantasyManager.Domain.Services;
using FantasyManager.Data.Services;
using FantasyManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using FantasyManager.WPF.State.Authenticators;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Application.Services;

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

            //FootballContextFactory footballContextFactory = serviceProvider.GetRequiredService<FootballContextFactory>();
            //IMapper mapper = serviceProvider.GetRequiredService<IMapper>();

            //IAuthenticationService service = serviceProvider.GetRequiredService<IAuthenticationService>();
            //service.Register("sim", "sim", "sim", "sim@sim");

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<FootballContextFactory>();

            var mapper = AutoMapperConfig.ConfigureAutoMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IDataService<League>, GenericDataService<League>>();
            services.AddSingleton<IDataService<Team>, GenericDataService<Team>>();
            services.AddSingleton<IDataService<Season>, GenericDataService<Season>>();
            services.AddSingleton<IPlayerModelService, PlayerModelService>();
            services.AddSingleton<ILeagueModelService, LeagueModelService>();
            services.AddSingleton<ITeamModelService, TeamModelService>();
            services.AddSingleton<ISeasonModelService, SeasonModelService>();
            services.AddSingleton<IUserTeamModelService, UserTeamModelService>();
            services.AddSingleton<IUserService, UserDataService>();
            services.AddSingleton<IUserTeamService, UserTeamDataService>();
            services.AddSingleton<IPlayerService, PlayerDataService>();
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddSingleton<IFantasyManagerViewModelFactory, FantasyManagerViewModelFactory>();

            services.AddSingleton <ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
            });
            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => new HomeViewModel();
            });
            services.AddSingleton<CreateViewModel<CreateTeamViewModel>>(services =>
            {
                return () => new CreateTeamViewModel(services.GetRequiredService<IAuthenticator>(), 
                    services.GetRequiredService<ILeagueModelService>(),
                    services.GetRequiredService<ITeamModelService>(),
                    services.GetRequiredService<ISeasonModelService>(),
                    services.GetRequiredService<IUserTeamModelService>());
            });
            services.AddSingleton<CreateViewModel<DraftTeamViewModel>>(services =>
            {
                return () => new DraftTeamViewModel(services.GetRequiredService<IPlayerModelService>());
            });
            services.AddSingleton<CreateViewModel<PlaySeasonViewModel>>(services =>
            {
                return () => new PlaySeasonViewModel();
            });

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new WPF.MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
