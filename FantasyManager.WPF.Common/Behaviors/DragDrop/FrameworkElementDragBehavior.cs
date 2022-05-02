using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;

namespace FantasyManager.WPF.Common.Behaviors.DragDrop
{
    public class FrameworkElementDragBehavior : Behavior<FrameworkElement>
    {
        public bool isMouseClicked = false;

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseLeftButtonDown += new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonDown);
            this.AssociatedObject.MouseLeftButtonUp += new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonUp);
            this.AssociatedObject.MouseLeave += new MouseEventHandler(AssociatedObject_MouseLeave);
        }

        void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMouseClicked = true;

            e.Handled = true;
        }

        void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseClicked = false;

            e.Handled = true;
        }

        void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isMouseClicked)
            {
                IDragable dragObject = AssociatedObject.DataContext as IDragable;
                if (dragObject != null)
                {
                    DataObject data = new DataObject();
                    data.SetData(dragObject.DataType, AssociatedObject.DataContext);
                    System.Windows.DragDrop.DoDragDrop(AssociatedObject, data, DragDropEffects.Move);
                }
            }
            isMouseClicked = false;
        }
    }
}
