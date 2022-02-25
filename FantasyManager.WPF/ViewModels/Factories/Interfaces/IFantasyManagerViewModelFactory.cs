using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Factories.Interfaces
{
    public interface IFantasyManagerViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
