// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var events = Events.FromJson(jsonString);

namespace MeetupApp.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Events
    {
        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public EventName Name { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("local_date")]
        public DateTimeOffset LocalDate { get; set; }

        [JsonProperty("local_time")]
        public LocalTime LocalTime { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("utc_offset")]
        public long UtcOffset { get; set; }

        [JsonProperty("waitlist_count")]
        public long WaitlistCount { get; set; }

        [JsonProperty("yes_rsvp_count")]
        public long YesRsvpCount { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("group")]
        public Group Group { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("how_to_find_us")]
        public HowToFindUs HowToFindUs { get; set; }

        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }
    }

    public partial class Group
    {
        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("name")]
        public GroupName Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("join_mode")]
        public JoinMode JoinMode { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("urlname")]
        public Urlname Urlname { get; set; }

        [JsonProperty("who")]
        public Who Who { get; set; }

        [JsonProperty("localized_location")]
        public LocalizedLocation LocalizedLocation { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }
    }

    public partial class Venue
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public VenueName Name { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("repinned")]
        public bool Repinned { get; set; }

        [JsonProperty("address_1")]
        public Address1 Address1 { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("localized_country_name")]
        public LocalizedCountryName LocalizedCountryName { get; set; }

        [JsonProperty("zip")]
        public Zip Zip { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }
    }

    public enum JoinMode { Open };

    public enum LocalizedLocation { TorontoOn };

    public enum GroupName { TorontoMobileNetDevelopersGroup };

    public enum Region { EnUs };

    public enum Urlname { TorontoMobileDevelopers };

    public enum Who { Members };

    public enum HowToFindUs { The483QueenWestUpTheStairsToThe3RdFloor };

    public enum LocalTime { The1800 };

    public enum EventName { AutomatedUiTestingForMobile, Tbd };

    public enum Status { Upcoming };

    public enum Address1 { The483QueenStW };

    public enum City { Toronto };

    public enum Country { Ca };

    public enum LocalizedCountryName { Canada };

    public enum VenueName { HackerYou };

    public enum State { On };

    public enum Zip { Empty };

    public enum Visibility { Public };

    public partial class Events
    {
        public static Events[] FromJson(string json) => JsonConvert.DeserializeObject<Events[]>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this Events[] self) => JsonConvert.SerializeObject(self);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new CountryConverter(),
                new LocalizedCountryNameConverter(),
                new VenueNameConverter(),
                new JoinModeConverter(),
                new StateConverter(),
                new LocalizedLocationConverter(),
                new ZipConverter(),
                new GroupNameConverter(),
                new VisibilityConverter(),
                new RegionConverter(),
                new UrlnameConverter(),
                new WhoConverter(),
                new HowToFindUsConverter(),
                new LocalTimeConverter(),
                new EventNameConverter(),
                new StatusConverter(),
                new Address1Converter(),
                new CityConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CountryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Country) || t == typeof(Country?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ca")
            {
                return Country.Ca;
            }
            throw new Exception("Cannot unmarshal type Country");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Country)untypedValue;
            if (value == Country.Ca)
            {
                serializer.Serialize(writer, "ca"); return;
            }
            throw new Exception("Cannot marshal type Country");
        }
    }

    internal class LocalizedCountryNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocalizedCountryName) || t == typeof(LocalizedCountryName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Canada")
            {
                return LocalizedCountryName.Canada;
            }
            throw new Exception("Cannot unmarshal type LocalizedCountryName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (LocalizedCountryName)untypedValue;
            if (value == LocalizedCountryName.Canada)
            {
                serializer.Serialize(writer, "Canada"); return;
            }
            throw new Exception("Cannot marshal type LocalizedCountryName");
        }
    }

    internal class VenueNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VenueName) || t == typeof(VenueName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Hacker You")
            {
                return VenueName.HackerYou;
            }
            throw new Exception("Cannot unmarshal type VenueName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (VenueName)untypedValue;
            if (value == VenueName.HackerYou)
            {
                serializer.Serialize(writer, "Hacker You"); return;
            }
            throw new Exception("Cannot marshal type VenueName");
        }
    }

    internal class JoinModeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(JoinMode) || t == typeof(JoinMode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "open")
            {
                return JoinMode.Open;
            }
            throw new Exception("Cannot unmarshal type JoinMode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (JoinMode)untypedValue;
            if (value == JoinMode.Open)
            {
                serializer.Serialize(writer, "open"); return;
            }
            throw new Exception("Cannot marshal type JoinMode");
        }
    }

    internal class StateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(State) || t == typeof(State?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "ON")
            {
                return State.On;
            }
            throw new Exception("Cannot unmarshal type State");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (State)untypedValue;
            if (value == State.On)
            {
                serializer.Serialize(writer, "ON"); return;
            }
            throw new Exception("Cannot marshal type State");
        }
    }

    internal class LocalizedLocationConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocalizedLocation) || t == typeof(LocalizedLocation?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Toronto, ON")
            {
                return LocalizedLocation.TorontoOn;
            }
            throw new Exception("Cannot unmarshal type LocalizedLocation");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (LocalizedLocation)untypedValue;
            if (value == LocalizedLocation.TorontoOn)
            {
                serializer.Serialize(writer, "Toronto, ON"); return;
            }
            throw new Exception("Cannot marshal type LocalizedLocation");
        }
    }

    internal class ZipConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Zip) || t == typeof(Zip?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "")
            {
                return Zip.Empty;
            }
            throw new Exception("Cannot unmarshal type Zip");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Zip)untypedValue;
            if (value == Zip.Empty)
            {
                serializer.Serialize(writer, ""); return;
            }
            throw new Exception("Cannot marshal type Zip");
        }
    }

    internal class GroupNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GroupName) || t == typeof(GroupName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Toronto Mobile .NET Developers Group")
            {
                return GroupName.TorontoMobileNetDevelopersGroup;
            }
            throw new Exception("Cannot unmarshal type GroupName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (GroupName)untypedValue;
            if (value == GroupName.TorontoMobileNetDevelopersGroup)
            {
                serializer.Serialize(writer, "Toronto Mobile .NET Developers Group"); return;
            }
            throw new Exception("Cannot marshal type GroupName");
        }
    }

    internal class VisibilityConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Visibility) || t == typeof(Visibility?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "public")
            {
                return Visibility.Public;
            }
            throw new Exception("Cannot unmarshal type Visibility");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Visibility)untypedValue;
            if (value == Visibility.Public)
            {
                serializer.Serialize(writer, "public"); return;
            }
            throw new Exception("Cannot marshal type Visibility");
        }
    }

    internal class RegionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Region) || t == typeof(Region?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "en_US")
            {
                return Region.EnUs;
            }
            throw new Exception("Cannot unmarshal type Region");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Region)untypedValue;
            if (value == Region.EnUs)
            {
                serializer.Serialize(writer, "en_US"); return;
            }
            throw new Exception("Cannot marshal type Region");
        }
    }

    internal class UrlnameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Urlname) || t == typeof(Urlname?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "TorontoMobileDevelopers")
            {
                return Urlname.TorontoMobileDevelopers;
            }
            throw new Exception("Cannot unmarshal type Urlname");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Urlname)untypedValue;
            if (value == Urlname.TorontoMobileDevelopers)
            {
                serializer.Serialize(writer, "TorontoMobileDevelopers"); return;
            }
            throw new Exception("Cannot marshal type Urlname");
        }
    }

    internal class WhoConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Who) || t == typeof(Who?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Members")
            {
                return Who.Members;
            }
            throw new Exception("Cannot unmarshal type Who");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Who)untypedValue;
            if (value == Who.Members)
            {
                serializer.Serialize(writer, "Members"); return;
            }
            throw new Exception("Cannot marshal type Who");
        }
    }

    internal class HowToFindUsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(HowToFindUs) || t == typeof(HowToFindUs?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "483 Queen West, up the stairs to the 3rd Floor")
            {
                return HowToFindUs.The483QueenWestUpTheStairsToThe3RdFloor;
            }
            throw new Exception("Cannot unmarshal type HowToFindUs");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (HowToFindUs)untypedValue;
            if (value == HowToFindUs.The483QueenWestUpTheStairsToThe3RdFloor)
            {
                serializer.Serialize(writer, "483 Queen West, up the stairs to the 3rd Floor"); return;
            }
            throw new Exception("Cannot marshal type HowToFindUs");
        }
    }

    internal class LocalTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocalTime) || t == typeof(LocalTime?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "18:00")
            {
                return LocalTime.The1800;
            }
            throw new Exception("Cannot unmarshal type LocalTime");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (LocalTime)untypedValue;
            if (value == LocalTime.The1800)
            {
                serializer.Serialize(writer, "18:00"); return;
            }
            throw new Exception("Cannot marshal type LocalTime");
        }
    }

    internal class EventNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(EventName) || t == typeof(EventName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Automated UI Testing for Mobile":
                    return EventName.AutomatedUiTestingForMobile;
                case "TBD":
                    return EventName.Tbd;
            }
            throw new Exception("Cannot unmarshal type EventName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (EventName)untypedValue;
            switch (value)
            {
                case EventName.AutomatedUiTestingForMobile:
                    serializer.Serialize(writer, "Automated UI Testing for Mobile"); return;
                case EventName.Tbd:
                    serializer.Serialize(writer, "TBD"); return;
            }
            throw new Exception("Cannot marshal type EventName");
        }
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "upcoming")
            {
                return Status.Upcoming;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Status)untypedValue;
            if (value == Status.Upcoming)
            {
                serializer.Serialize(writer, "upcoming"); return;
            }
            throw new Exception("Cannot marshal type Status");
        }
    }

    internal class Address1Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Address1) || t == typeof(Address1?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "483 Queen St W")
            {
                return Address1.The483QueenStW;
            }
            throw new Exception("Cannot unmarshal type Address1");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Address1)untypedValue;
            if (value == Address1.The483QueenStW)
            {
                serializer.Serialize(writer, "483 Queen St W"); return;
            }
            throw new Exception("Cannot marshal type Address1");
        }
    }

    internal class CityConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(City) || t == typeof(City?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Toronto")
            {
                return City.Toronto;
            }
            throw new Exception("Cannot unmarshal type City");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (City)untypedValue;
            if (value == City.Toronto)
            {
                serializer.Serialize(writer, "Toronto"); return;
            }
            throw new Exception("Cannot marshal type City");
        }
    }
}
