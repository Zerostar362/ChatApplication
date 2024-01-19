using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApplication.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        public string Username { get; set; }
        public string Chat { get; set; }

        public string MessageToSend { get; set; }
        public ICommand SendMessage { get; set; }

        public ChatViewModel() 
        {

        }
    }
}
