using System.Collections.Generic;
using Plugin.Iconize;

namespace MeetupApp.Fonts
{
    public static class FontAwesomeRegular
    {
        private static IIcon _meetings = new Icon(nameof(Meetings), '\uf073');
        private static IIcon _connect = new Icon(nameof(Connect), '\uf1e6');
        private static IIcon _about = new Icon(nameof(About), '\uf129');

        public static IList<IIcon> Items { get; } = new List<IIcon>
        {
            _meetings,
            _connect,
            _about
        };

        public static string MeetingsKey => _meetings.Key;
        public static string ConnectKey => _connect.Key;
        public static string AboutKey => _about.Key;

        public static string Meetings => _meetings.Character.ToString();
        public static string Connect => _connect.Character.ToString();
        public static string About => _about.Character.ToString();
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
