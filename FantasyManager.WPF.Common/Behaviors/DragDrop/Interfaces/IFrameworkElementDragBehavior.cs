using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces
{
    public interface IFrameworkElementDragBehavior
    {
        void AssociatedObject_MouseLeave(object sender, MouseEventArgs e);
        void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e);
        void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e);
    }
}
