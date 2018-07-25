using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace MeetupApp.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        public AboutPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "About";
        }
    }
}
