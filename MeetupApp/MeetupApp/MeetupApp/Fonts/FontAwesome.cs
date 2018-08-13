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
        private static IIcon _meetup = new Icon(nameof(Meetup), '\uf2e0');
        private static IIcon _gitHub = new Icon(nameof(GitHub), '\uf09b');
        private static IIcon _youTube = new Icon(nameof(YouTube), '\uf167');
        private static IIcon _twitter = new Icon(nameof(Twitter), '\uf099');
        private static IIcon _whatsApp = new Icon(nameof(WhatsApp), '\uf232');
        private static IIcon _facebook = new Icon(nameof(Facebook), '\uf39e');

        public static IList<IIcon> Items { get; } = new List<IIcon>
        {
            _meetup,
            _gitHub,
            _youTube,
            _twitter,
            _whatsApp,
            _facebook,
        };

        public static string MeetupKey => _meetup.Key;
        public static string GitHubKey => _gitHub.Key;
        public static string YouTubeKey => _youTube.Key;
        public static string TwitterKey => _twitter.Key;
        public static string WhatsAppKey => _whatsApp.Key;
        public static string FacebookKey => _facebook.Key;

        public static string Meetup => _meetup.Character.ToString();
        public static string GitHub => _gitHub.Character.ToString();
        public static string YouTube => _youTube.Character.ToString();
        public static string Twitter => _twitter.Character.ToString();
        public static string WhatsApp => _whatsApp.Character.ToString();
        public static string Facebook => _facebook.Character.ToString();
    }
}
