using FantasyManager.WPF.Common.Behaviors.DragDrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FantasyManager.WPF.Behaviors.DragDrop
{
    public class PlayerDraftViewModelAdorner : FrameworkElementAdorner
    {
        private BitmapImage _image;

        public PlayerDraftViewModelAdorner(UIElement adornedElement, BitmapImage image) : base(adornedElement)
        {
            _image = image;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.RenderSize);

            drawingContext.DrawImage(_image, adornedElementRect);
        }
    }
}
