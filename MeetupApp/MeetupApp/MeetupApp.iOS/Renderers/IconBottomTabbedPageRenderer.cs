using System;
using System.Threading.Tasks;
using CoreGraphics;
using CoreText;
using Foundation;
using MeetupApp.Controls;
using MeetupApp.Fonts;
using MeetupApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconBottomTabbedPage), typeof(IconBottomTabbedPageRenderer))]
namespace MeetupApp.iOS.Renderers
{
    /// <summary>
    /// Defines the <see cref="IconBottomTabbedPage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.TabbedRenderer" />
    public class IconBottomTabbedPageRenderer : TabbedRenderer
    {
        /// <inheritdoc />
        protected override Task<Tuple<UIImage, UIImage>> GetIcon(Page page)
        {
                if (!(page.Icon is null) && !(page.Icon.File is null))
            {
                if (FontAwesomeRegular.Items.TryGetValue(page.Icon.File, out var iconChar))
                {
                    return Task.FromResult(Tuple.Create(GetUIImage(iconChar, 25f), (UIImage)null));
                }
            }

            return base.GetIcon(page);
        }

        /// <summary>
        /// To the UI image.
        /// </summary>
        /// <param name="iconChar">The character value for the desired icon.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        private UIImage GetUIImage(char iconChar, nfloat size)
        {
            var attributedString = new NSAttributedString($"{iconChar}", new CTStringAttributes
            {
                Font = new CTFont(FontAwesomeRegular.FontName, size),
                ForegroundColorFromContext = true
            });

            var boundSize = attributedString.GetBoundingRect(new CGSize(10000f, 10000f), NSStringDrawingOptions.UsesLineFragmentOrigin, null).Size;

            UIGraphics.BeginImageContextWithOptions(boundSize, false, 0f);
            attributedString.DrawString(new CGRect(0f, 0f, boundSize.Width, boundSize.Height));
            using (var image = UIGraphics.GetImageFromCurrentImageContext())
            {
                UIGraphics.EndImageContext();

                return image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            }
        }
    }
}
