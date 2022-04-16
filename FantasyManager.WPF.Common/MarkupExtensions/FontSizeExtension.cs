using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FantasyManager.WPF.Common.MarkupExtensions
{
    [TypeConverter(typeof(FontSizeExtension))]
    public class FontSizeExtension : MarkupExtension
    {
        public double FontSize { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return FontSize;
        }
    }
}
