using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeetupApp.Templates
{
    public partial class SocialIcon : ContentView
    {
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText),
            typeof(string),
            typeof(SocialIcon),
            default(string));

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource),
            typeof(string),
            typeof(SocialIcon),
            default(string));

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
            typeof(ICommand),
            typeof(SocialIcon),
            default(ICommand));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter),
            typeof(object),
            typeof(SocialIcon),
            default);
        
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
        ///     ImageSource summary. This is a bindable property.
        /// </summary>
        public string ImageSource
        {
            get => (string)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        /// <summary>
        ///     Command summary. This is a bindable property.
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        /// <summary>
        ///     CommandParameter summary. This is a bindable property.
        /// </summary>
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
    }
}
