using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;

namespace MeetupApp.Droid
{
    [Activity(Label = "TO Mobile Devs", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            InitDependencies();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }

        private void InitDependencies()
        {
            Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

