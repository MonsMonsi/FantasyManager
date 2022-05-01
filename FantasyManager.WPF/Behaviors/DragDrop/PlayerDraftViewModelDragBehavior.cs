using FantasyManager.WPF.Common.Behaviors.DragDrop;
using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using FantasyManager.WPF.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FantasyManager.WPF.Behaviors.DragDrop
{
    public class PlayerDraftViewModelDragBehavior : FrameworkElementDragBehavior
    {
        private PlayerDraftViewModelAdorner _adorner;
        //public override void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    if (isMouseClicked)
        //    {
        //        AssociatedObject.GiveFeedback += new GiveFeedbackEventHandler(AssociatedObject_GiveFeedback);

        //        IDragable dragObject = AssociatedObject.DataContext as IDragable;
        //        if (dragObject != null)
        //        {
        //            DataObject data = new DataObject();
        //            data.SetData(dragObject.DataType, AssociatedObject.DataContext);
        //            System.Windows.DragDrop.DoDragDrop(AssociatedObject, data, DragDropEffects.Move);
        //        }
        //    }
        //    isMouseClicked = false;
        //    AssociatedObject.GiveFeedback -= AssociatedObject_GiveFeedback;
        //}

        void AssociatedObject_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (AssociatedObject.DataContext is PlayerDraftViewModel player)
            {   
                BitmapImage image = new BitmapImage(new Uri(player.Image));

                if (_adorner is null)
                    _adorner = new PlayerDraftViewModelAdorner(sender as UIElement, image);

                _adorner.Update();
            }
            e.Handled = true;
        }
    }
}
