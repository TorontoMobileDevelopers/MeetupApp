using System;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using System.Windows.Input;
using Prism.Commands;

namespace MeetupApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual ICommand NavigateToWebUrlCommand => new DelegateCommand<string>(url => Device.OpenUri(new Uri(url)));

        public virtual void OnNavigatedFrom(INavigationParameters parameters) {}

        public virtual void OnNavigatedTo(INavigationParameters parameters) {}

        public virtual void OnNavigatingTo(INavigationParameters parameters) {}

        public virtual void Destroy() {}
    }
}
