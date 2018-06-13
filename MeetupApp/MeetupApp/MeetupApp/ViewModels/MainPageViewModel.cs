using Prism.Navigation;
using System.Windows.Input;
using MeetupApp.Commands;
using MeetupApp.Services;

namespace MeetupApp.ViewModels
{
	public class MainPageViewModel : ViewModelBase, INavigationAware
    {
        private ICommand _loadEventsCommand;
        public ICommand RefreshCommand => _loadEventsCommand;

        public MainPageViewModel(INavigationService navigationService, ILoadEventsCommand loadEventsCommand)
            : base (navigationService)
        {
            Title = "Main Page";
            _loadEventsCommand = loadEventsCommand;
        }

		public override void OnNavigatingTo(NavigationParameters parameters)
        {
            _loadEventsCommand.Execute(null);
        }
	}
}