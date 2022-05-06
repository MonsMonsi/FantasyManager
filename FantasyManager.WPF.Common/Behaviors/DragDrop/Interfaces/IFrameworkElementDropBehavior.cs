using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces
{
    public interface IFrameworkElementDropBehavior
    {
        void AssociatedObject_Drop(object sender, DragEventArgs e);
        void AssociatedObject_DragLeave(object sender, DragEventArgs e);
        void AssociatedObject_DragOver(object sender, DragEventArgs e);
        void AssociatedObject_DragEnter(object sender, DragEventArgs e);

    }
}
