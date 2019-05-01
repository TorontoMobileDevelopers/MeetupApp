using System.Collections.Generic;

namespace MeetupApp.Fonts
{
    public static class FontAwesomeRegular
    {
        public const string MeetingsKey = "Meetings";
        public const string ConnectKey = "Connect";
        public const string AboutKey = "About";

        public static IDictionary<string, char> Items { get; } = new Dictionary<string, char>
        {
            { MeetingsKey, '\uf073'},
            { ConnectKey, '\uf1e6'},
            { AboutKey, '\uf129'}
        };

        public static string FontFamily => "Font Awesome 5 Pro";
        public static string FontName => "Font Awesome 5 Pro Regular";
        public static string FontPath => "fa-regular-400.ttf";
    }

    public static class FontAwesomeBrands
    {
        public static string Meetup => '\uf2e0'.ToString();
        public static string GitHub => '\uf09b'.ToString();
        public static string YouTube => '\uf167'.ToString();
        public static string Twitter => '\uf099'.ToString();
        public static string WhatsApp => '\uf232'.ToString();
        public static string Facebook => '\uf39e'.ToString();
    }
}
