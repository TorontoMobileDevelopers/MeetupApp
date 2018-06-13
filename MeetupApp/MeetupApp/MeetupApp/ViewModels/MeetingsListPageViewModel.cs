using Prism.Navigation;
using System.Windows.Input;
using MeetupApp.Commands;

namespace MeetupApp.ViewModels
{
    public class MeetingsListPageViewModel : ViewModelBase, INavigationAware
    {
        private ICommand _loadEventsCommand;
        public ICommand RefreshCommand => _loadEventsCommand;

        public MeetingsListPageViewModel(INavigationService navigationService, ILoadEventsCommand loadEventsCommand)
            : base (navigationService)
        {
            Title = "Meetings";
            _loadEventsCommand = loadEventsCommand;
        }

		public override void OnNavigatingTo(NavigationParameters parameters)
        {
            _loadEventsCommand.Execute(null);
        }
	}
}