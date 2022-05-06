using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using FantasyManager.WPF.Common.Helpers;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FantasyManager.WPF.Common.Behaviors.DragDrop
{
    public class FrameworkElementDragBehavior : Behavior<FrameworkElement>, IFrameworkElementDragBehavior
    {
        private bool _isMouseClicked = false;
        private Cursor _customCursor = null;
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeave += new MouseEventHandler(AssociatedObject_MouseLeave);
            AssociatedObject.GiveFeedback += new GiveFeedbackEventHandler(AssociatedObject_GiveFeedback);
            AssociatedObject.MouseLeftButtonDown += new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonDown);
            AssociatedObject.MouseLeftButtonUp += new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonUp);
        }
        public void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_isMouseClicked)
            {
                var dragSource = AssociatedObject.DataContext;

                if (dragSource is not null)
                {
                    var data = new DataObject();
                    data.SetData(dragSource.GetType(), dragSource);
                    System.Windows.DragDrop.DoDragDrop(AssociatedObject, data, DragDropEffects.Move);
                }
            }
            _isMouseClicked = false;
        }

        public void AssociatedObject_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effects == DragDropEffects.None)
            {
                if (_customCursor == null)
                    _customCursor = CursorHelper.CreateCursor(e.Source as UIElement);

                if (_customCursor != null)
                {
                    e.UseDefaultCursors = false;
                    Mouse.SetCursor(_customCursor);
                }
            }
            else
                e.UseDefaultCursors = true;

            e.Handled = true;
        }

        public void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseClicked = true;
        }

        public void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseClicked = false;
        }
    }
}
