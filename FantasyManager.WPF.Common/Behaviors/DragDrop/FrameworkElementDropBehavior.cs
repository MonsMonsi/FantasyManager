using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
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
    public class FrameworkElementDropBehavior : Behavior<FrameworkElement>, IFrameworkElementDropBehavior
    {
        #region DependencyProperties

        public ICommand HandleDropCommand
        {
            get { return (ICommand)GetValue(HandleDropCommandProperty); }
            set { SetValue(HandleDropCommandProperty, value); }
        }

        public static readonly DependencyProperty HandleDropCommandProperty =
            DependencyProperty.Register("HandleDropCommand", typeof(ICommand), typeof(FrameworkElementDropBehavior), new PropertyMetadata(null));
        #endregion

        private FrameworkElementAdorner _adorner;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.AllowDrop = true;
            AssociatedObject.DragEnter += new DragEventHandler(AssociatedObject_DragEnter);
            AssociatedObject.DragOver += new DragEventHandler(AssociatedObject_DragOver);
            AssociatedObject.DragLeave += new DragEventHandler(AssociatedObject_DragLeave);
            AssociatedObject.Drop += new DragEventHandler(AssociatedObject_Drop);
        }

        public void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            var format = e.Data.GetFormats().First();

            if (e.Data.GetDataPresent(format))
            {
                HandleDropCommand?.Execute(e.Data.GetData(format));
            }

            if (_adorner != null)
                _adorner.Remove();

            e.Handled = true;
            return;
        }

        public void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            if (_adorner == null)
                _adorner = new FrameworkElementAdorner(sender as UIElement);
            e.Handled = true;
        }

        public void AssociatedObject_DragOver(object sender, DragEventArgs e)
        {
            var format = e.Data.GetFormats().First();

            if (e.Data.GetDataPresent(format))
            {
                SetDragDropEffects(e);
                if (_adorner != null)
                    _adorner.Update();
            }

            e.Handled = true;
        }

        public void AssociatedObject_DragLeave(object sender, DragEventArgs e)
        {
            if (_adorner != null)
                _adorner.Remove();
            e.Handled = true;
        }

        private void SetDragDropEffects(DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            var format = e.Data.GetFormats().First();

            if (e.Data.GetDataPresent(format))
            {
                e.Effects = DragDropEffects.Move;
            }
        }
    }
}
