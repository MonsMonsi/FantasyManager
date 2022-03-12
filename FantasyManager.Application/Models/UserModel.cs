

namespace FantasyManager.Application.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime JoinedAt { get; set; }
        public virtual IList<UserTeamModel> UserTeams { get; set; } = new List<UserTeamModel>();
    }
}
