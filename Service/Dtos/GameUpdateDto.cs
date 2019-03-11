using PlayByPlay.Service.Models;

namespace PlayByPlay.Service.Dtos
{
    public class GameUpdateDto
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public PlaysPage PlaysPage { get; set; }
    }
}
