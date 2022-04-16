using FantasyManager.Application.Enums;
using System.Windows.Media.Imaging;

namespace FantasyManager.Application.Helpers
{
    public static class ImageUtil
    {
        public static BitmapImage UriToBitmapImage(string uri, ImageSize imageSize)
        {
            if (uri != null)
            {
                var size = GetSize(imageSize);

                var image = new BitmapImage();

                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(uri);
                image.DecodePixelWidth = size;
                image.EndInit();

                return image;
            }

            return null;
        }

        private static int GetSize(ImageSize imageSize)
        {
            switch (imageSize)
            {
                case ImageSize.Small:
                    return 50;
                case ImageSize.Medium:
                    return 80;
                case ImageSize.Large:
                    return 120;
                default:
                    return 0;
            }
        }
    }
}
