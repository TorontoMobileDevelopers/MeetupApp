using System;
using System.Text.RegularExpressions;

namespace MeetupApp.Models
{
    public interface IRssFeedItem
    {
        string Description { get; set; }
        string Link { get; set; }
        string PublishDate { get; set; }
        string Author { get; set; }
        string AuthorEmail { get; set; }
        int Id { get; set; }
        string Title { get; set; }
        string Caption { get; }
        bool ShowImage { get; set; }

        /// <summary>
        /// When we set the image, mark show image as true
        /// </summary>
        string Image { get; set; }
    }

    public class RssFeedItem : IRssFeedItem
    {
        public string Description { get; set; }
        public string Link { get; set; }
        public string PublishDate { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public int Id { get; set; }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                //RSS feed always is "Author : Title", split it here and set correctly
                var splitIndex = title.IndexOf(":", StringComparison.OrdinalIgnoreCase);
                if (splitIndex > -1)
                {
                    Author = title.Substring(0, splitIndex).Trim();
                    title = title.Substring(splitIndex + 1, title.Length - splitIndex - 1).Trim();
                }
            }
        }

        private string caption;

        public string Caption
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(caption))
                    return caption;

                if (string.IsNullOrWhiteSpace(Description)) return string.Empty;

                //get rid of HTML tags
                caption = Regex.Replace(Description, "<[^>]*>", string.Empty);

                //get rid of multiple blank lines
                caption = Regex.Replace(caption, @"^\s*$\n", string.Empty, RegexOptions.Multiline);

                return caption;
            }
        }

        private bool showImage = true;

        public bool ShowImage
        {
            get { return showImage; }
            set { showImage = value; }
        }

        private string image = @"https://secure.gravatar.com/avatar/70148d964bb389d42547834e1062c886?s=60&r=x&d=http%3a%2f%2fd1iqk4d73cu9hh.cloudfront.net%2fcomponents%2fimg%2fuser-icon.png";

        /// <summary>
        /// When we set the image, mark show image as true
        /// </summary>
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                showImage = true;
            }

        }

    }
}

