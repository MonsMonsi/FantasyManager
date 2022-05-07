using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class TutorialViewModel : ViewModelBase
    {
        #region OnChangeProperties

        private string _tutorialMessage;
        public string TutorialMessage
        {
            get { return _tutorialMessage; }
            set
            {
                _tutorialMessage = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
