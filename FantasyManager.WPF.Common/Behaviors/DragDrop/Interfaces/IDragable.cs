using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces
{
    public interface IDragable
    {
        Type DataType { get; }
        void Remove(object i);
    }
}
