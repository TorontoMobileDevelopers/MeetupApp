using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeetupApp.Controls
{
    public partial class SocialIcon : ContentView
    {
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText),
            typeof(string),
            typeof(SocialIcon),
            default(string));

        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon),
            typeof(string),
            typeof(SocialIcon),
            default(string));

        public static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url),
            typeof(string),
            typeof(SocialIcon),
            default(string));

        public SocialIcon()
        {
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        ///     LabelText summary. This is a bindable property.
        /// </summary>
        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        /// <summary>
        /// Icon property (bindable)
        /// </summary>
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        ///     Url summary. This is a bindable property.
        /// </summary>
        public string Url
        {
            get => (string)GetValue(UrlProperty);
            set => SetValue(UrlProperty, value);
        }

        public void OnTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(Url));
        }
    }
}
