using FantasyManager.Application.Enums;
using System.Windows.Media.Imaging;

namespace FantasyManager.Application.Helpers
{
    public static class ImageUtil
    {
        public static BitmapImage UriToBitmapImage(string uri, ImageSize imageSize)
        {
            if (uri != null && File.Exists(uri))
            {
                var size = GetSize(imageSize);

                var image = new BitmapImage();

                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(uri);
                image.DecodePixelHeight = size;
                image.DecodePixelWidth = (int)Math.Floor(size * 0.75);
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
                    return 300;
                case ImageSize.Medium:
                    return 500;
                case ImageSize.Large:
                    return 800;
                default:
                    return 0;
            }
        }
    }
}
