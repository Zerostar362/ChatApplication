using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public int ListeningPort 
        {
            get => _listeningPort;
            set
            {
                _listeningPort = value;
                OnPropertyChanged();
            }
        }
        private int _listeningPort = 0;
    }
}
