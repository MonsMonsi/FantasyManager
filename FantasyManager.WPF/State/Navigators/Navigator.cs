using AutoMapper;
using FantasyManager.WPF.Commands;
using FantasyManager.WPF.Models.Properties;
using FantasyManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FantasyManager.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        private readonly IMapper _mapper; //TODO:  just a workaround => delete when possible!!!!

        public Navigator(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this, _mapper);
    }
}
