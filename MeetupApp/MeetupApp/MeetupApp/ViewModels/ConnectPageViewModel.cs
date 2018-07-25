using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MeetupApp.ViewModels
{
    public class ConnectPageViewModel : ViewModelBase
    {
        public ConnectPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Connect";
        }
    }
}
