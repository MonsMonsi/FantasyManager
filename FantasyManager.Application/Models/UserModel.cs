

namespace FantasyManager.Application.Models.Data
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual IList<UserTeamModel> UserTeams { get; set; } = new List<UserTeamModel>();
    }
}
