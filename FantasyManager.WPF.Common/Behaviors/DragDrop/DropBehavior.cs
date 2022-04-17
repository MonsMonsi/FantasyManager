using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FantasyManager.WPF.Common.Behaviors.DragDrop
{
    public static class DropBehavior
    {
        #region The dependecy Property
        private static readonly DependencyProperty PreviewDropCommandProperty =
                    DependencyProperty.RegisterAttached
                    (
                        "PreviewDropCommand",
                        typeof(ICommand),
                        typeof(DropBehavior),
                        new PropertyMetadata(PreviewDropCommandPropertyChangedCallBack)
                    );
        #endregion

        #region The getter and setter
        public static void SetPreviewDropCommand(this UIElement inUIElement, ICommand inCommand)
        {
            inUIElement.SetValue(PreviewDropCommandProperty, inCommand);
        }

        private static ICommand GetPreviewDropCommand(UIElement inUIElement)
        {
            return (ICommand)inUIElement.GetValue(PreviewDropCommandProperty);
        }
        #endregion

        #region The PropertyChangedCallBack method

        private static void PreviewDropCommandPropertyChangedCallBack(
            DependencyObject inDependencyObject, DependencyPropertyChangedEventArgs inEventArgs)
        {
            UIElement uiElement = inDependencyObject as UIElement;

            if (uiElement is null) return;

            uiElement.Drop += (sender, args) =>
            {
                GetPreviewDropCommand(uiElement).Execute(args.Data);
                args.Handled = true;
            };
        }
        #endregion
    }
}
