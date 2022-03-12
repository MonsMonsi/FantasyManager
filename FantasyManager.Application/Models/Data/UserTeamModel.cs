

namespace FantasyManager.Application.Models.Data
{
    public class UserTeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool IsDrafted { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public int SeasonId { get; set; }
        public virtual SeasonModel Season { get; set; }
        public virtual IList<UserTeamSquadModel> UserTeamSquads { get; set; } = new List<UserTeamSquadModel>();
    }
}
