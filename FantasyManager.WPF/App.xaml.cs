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
using FantasyManager.WPF.ViewModels.Controls;

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

            // LoginViewModel
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
            });

            // HomeViewModel
            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => new HomeViewModel();
            });

            // CreateTeamViewModel
            services.AddSingleton<CreateViewModel<CreateTeamViewModel>>(services =>
            {
                return () => new CreateTeamViewModel(services.GetRequiredService<TutorialViewModel>(),
                    services.GetRequiredService<LeagueSelectionViewModel>());
            });

            // DraftTeamViewModel
            services.AddSingleton<CreateViewModel<DraftTeamViewModel>>(services =>
            {
                return () => new DraftTeamViewModel(services.GetRequiredService<PlayerDraftListViewModel>(),
                    services.GetRequiredService<UserTeamFormationViewModel>());
            });

            // PlaySeasonViewModel
            services.AddSingleton<CreateViewModel<PlaySeasonViewModel>>(services =>
            {
                return () => new PlaySeasonViewModel();
            });

            // ControlViewModels
            services.AddSingleton<TutorialViewModel>();
            services.AddSingleton(services =>
            {
                return new LeagueSelectionViewModel(services.GetRequiredService<ILeagueModelService>());
            });
            services.AddSingleton(services =>
            {
                return new PlayerDraftListViewModel(services.GetRequiredService<IPlayerModelService>());
            });
            services.AddSingleton(services =>
            {
                return new UserTeamFormationViewModel();
            });

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
