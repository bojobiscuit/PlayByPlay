using System.Collections.Generic;

namespace PlayByPlay.Models
{
    public class Team
    {
        public int Score { get; set; }
        public int Shots { get; set; }
        public int Hits { get; set; }
        public IEnumerable<Player> Skaters { get; set; }
        public IEnumerable<Player> Goalies { get; set; }
    }
}