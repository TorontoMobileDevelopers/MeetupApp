using Prism.Navigation;
using System.Windows.Input;
using MeetupApp.Commands;
using Prism.Commands;
using Xamarin.Forms;
using MeetupApp.Models;
using System;

namespace MeetupApp.ViewModels
{
    public class MeetingsListPageViewModel : ViewModelBase
    {
        private ICommand _loadEventsCommand;
        public ICommand RefreshCommand => _loadEventsCommand;

        public MeetingsListPageViewModel(INavigationService navigationService, ILoadEventsCommand loadEventsCommand)
            : base (navigationService)
        {
            Title = "Meetings";
            _loadEventsCommand = loadEventsCommand;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            _loadEventsCommand.Execute(null);
        }

        public override ICommand NavigateToWebUrlCommand => new DelegateCommand<RssFeedItem>(item => Device.OpenUri(new Uri(item.Link)));
    }
}