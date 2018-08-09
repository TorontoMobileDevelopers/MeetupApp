using System.Collections.Generic;
using Plugin.Iconize;

namespace MeetupApp.Fonts
{
    public static class FontAwesome
    {
        static FontAwesome()
        {
            Items.Add(nameof(Meetup), _meetup);
            Items.Add(nameof(GitHub), _gitHub);
            Items.Add(nameof(YouTube), _youTube);
            Items.Add(nameof(Twitter), _twitter);
            Items.Add(nameof(WhatsApp), _whatsApp);
            Items.Add(nameof(Facebook), _facebook);
            Items.Add(nameof(Other), _other);

            Items.Add(nameof(Meetings), _meetings);
            Items.Add(nameof(Connect), _connect);
            Items.Add(nameof(About), _about);
        }

        public static IList<IIcon> Items { get; } = new List<IIcon>();

        public static string Meetup => _meetup.ToString();

        public static string GitHub => _gitHub.ToString();

        public static string YouTube => _youTube.ToString();

        public static string Twitter => _twitter.ToString();

        public static string WhatsApp => _whatsApp.ToString();

        public static string Facebook => _facebook.ToString();

        public static string Other => _other.ToString();

        public static string Meetings => _meetings.ToString();

        public static string Connect => _connect.ToString();

        public static string About => _about.ToString();

        private const char _meetup = '\uf2e0';
        private const char _gitHub = '\uf09b';
        private const char _youTube = '\uf167';
        private const char _twitter = '\uf099';
        private const char _whatsApp = '\uf232';
        private const char _facebook = '\uf39e';
        private const char _other = '\uf1a8';

        private const char _meetings = '\uf073';
        private const char _connect = '\uf1e6';
        private const char _about = '\uf129';
    }
}
