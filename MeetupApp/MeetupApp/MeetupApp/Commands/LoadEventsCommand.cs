using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using HttpTracer;
using MeetupApp.Models;
using MeetupApp.Services;
using MonkeyCache;
using MonkeyCache.SQLite;
using MvvmHelpers;
using Xamarin.Essentials;

namespace MeetupApp.Commands
{
    public class LoadEventsCommand : BaseCommand, ILoadEventsCommand
    {
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public LoadEventsCommand(IErrorManagementService errorManagementService) : base(errorManagementService)
        {
            ExecuteMethodAsync = LoadEventsFeed;
        }

        private ObservableRangeCollection<RssFeedItem> _eventList;
        public ObservableRangeCollection<RssFeedItem> EventList => _eventList = _eventList ?? new ObservableRangeCollection<RssFeedItem>();

        public async Task LoadEventsFeed()
        {
            try
            {
                const string url = "https://www.meetup.com/TorontoMobileDevelopers/events/rss/";
                IsRefreshing = true;

                string result;
                List<RssFeedItem> events;

                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    //using (var client = new HttpClient())//new HttpTracerHandler()))
                    using (var client = new HttpClient())
                    {
                        result = await client.GetStringAsync(url).ConfigureAwait(false);
                        events = await ParseFeed(result);
                        Barrel.Current.Add(url, events, TimeSpan.FromDays(1));
                    }
                }
                else
                {
                    events = Barrel.Current.Get<List<RssFeedItem>>(url);
                }

                EventList.ReplaceRange(events);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async Task<List<RssFeedItem>> ParseFeed(string rss)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(rss)) return new List<RssFeedItem>();
                var xdoc = XDocument.Parse(rss);
                var id = 0;
                return (from item in xdoc.Descendants("item")
                        select new RssFeedItem
                        {
                            Title = (string)item.Element("title"),
                            Description = (string)item.Element("description"),
                            Link = (string)item.Element("link"),
                            PublishDate = (string)item.Element("pubDate"),
                            AuthorEmail = (string)item.Element("author"),
                            Id = id++
                        }).ToList();
            });
        }
    }

    public interface ILoadEventsCommand : ICommand
    {
    }
}
