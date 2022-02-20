using AutoMapper;
using FantasyManager.WPF.Enums;
using FantasyManager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        private readonly IMapper _mapper;   //TODO:  just a workaround => delete when possible!!!!

        public MainViewModel(IMapper mapper)
        {
            _mapper = mapper;
            Navigator = new Navigator(_mapper);
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
