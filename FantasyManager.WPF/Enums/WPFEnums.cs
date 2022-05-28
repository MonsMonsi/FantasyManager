using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.Enums
{
    public enum ViewType
    {
        Main,
        Login,
        Home,
        CreateTeam,
        DraftTeam,
        PlaySeason
    }

    public enum PlayerPositionType
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Attacker
    }

    public enum CreateTeamStepType
    {
        LeagueSelection = 0,

    }
}
