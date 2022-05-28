using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.Messages
{
    public class StepBase<TStep>
    {
        public TStep CurrentStep { get; set; }
        public TStep NextStep { get; set; }
    }
}
