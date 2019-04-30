using System;
using Xamarin.Forms;
using MeetupApp.Droid.Renderers;
using Android.Support.Design.Widget;
using MeetupApp.Controls;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using System.Collections.Generic;
using Xamarin.Forms.Platform.Android.AppCompat;
using MeetupApp.Droid.Drawables;

[assembly: ExportRenderer(typeof(IconBottomTabbedPage), typeof(IconBottomTabbedPageRenderer))]
namespace MeetupApp.Droid.Renderers
{
    public class IconBottomTabbedPageRenderer : TabbedPageRenderer
    {
        private readonly List<String> _icons = new List<String>();

        public IconBottomTabbedPageRenderer(Context context) : base(context)
        {
        }

        /// <inheritdoc />
        protected override void OnAttachedToWindow()
        {
            UpdateTabbedIcons();

            base.OnAttachedToWindow();
        }

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            _icons.Clear();
            if (e.NewElement != null)
            {
                foreach (var page in e.NewElement.Children)
                {
                    if (page.Icon != null)
                    {
                        _icons.Add(page.Icon.File);
                        page.Icon = null;
                    }
                }
            }

            base.OnElementChanged(e);
        }

        /// <summary>
        /// Updates the menu item icons.
        /// </summary>
        private void UpdateTabbedIcons()
        {
            var relativeLayout = (Android.Widget.RelativeLayout)GetChildAt(0);
            var bottomNav = (BottomNavigationView)relativeLayout.GetChildAt(1);
            if (bottomNav == null || bottomNav.ChildCount == 0)
                return;
            
            for (var i = 0; i < bottomNav.Menu.Size(); i++)
            {
                var menuItemId = bottomNav.Menu.GetItem(i).ItemId;
                var menuItem = bottomNav.Menu.FindItem(menuItemId);

                if (_icons != null && i < _icons.Count)
                {
                    var iconKey = _icons[i];

                    var drawable = new IconDrawable(Context, iconKey).Color(Color.White.ToAndroid()).SizeDp(20);

                    menuItem.SetIcon(drawable);
                }
            }
        }
    }
}