using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FantasyManager.WPF.Common.MarkupExtensions
{
    public class FontSizeExtension : MarkupExtension
    {
        [TypeConverter("FontSizeExtension")]
        public double Size { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Size;
        }
    }
}
