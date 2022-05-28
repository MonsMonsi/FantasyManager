using FantasyManager.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.Messages
{
    public class CreateTeamStep : StepBase<CreateTeamStepType> 
    {
        public bool IsSubmitted { get; set; }
    }
}
