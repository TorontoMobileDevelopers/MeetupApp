using Prism;
using Prism.Ioc;
using MeetupApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Autofac;
using MeetupApp.Commands;
using MeetupApp.Services;
using MonkeyCache.SQLite;
using Xamarin.Essentials;
using Plugin.Iconize;
using MeetupApp.Fonts;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MeetupApp
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            Barrel.ApplicationId = AppInfo.PackageName;
            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<MeetingsListPage>();
            containerRegistry.RegisterForNavigation<AboutPage>();
            containerRegistry.RegisterForNavigation<ConnectPage>();

            containerRegistry.RegisterSingleton<IErrorManagementService, ErrorManagementService>();

            containerRegistry.Register<ILoadEventsCommand, LoadEventsCommand>();
        }

        public override void Initialize()
        {
            base.Initialize();
            Iconize.With(new FontAwesomeFreeIconModule());
                  //.With(new FontAwesomeBrandsIconModule());
        }
    }

    public class FontAwesomeFreeIconModule : IconModule
    {
        public FontAwesomeFreeIconModule()
            : base("Font Awesome 5 Pro", "Font Awesome 5 Pro Regular", "fa-regular-400.ttf", FontAwesomeRegular.Items) {}
    }

    public class FontAwesomeBrandsIconModule : IconModule
    {
        public FontAwesomeBrandsIconModule()
            : base("Font Awesome 5 Brands", "Font Awesome 5 Brands Regular", "fa-brands-400.ttf", FontAwesomeBrands.Items) { }
    }
}
