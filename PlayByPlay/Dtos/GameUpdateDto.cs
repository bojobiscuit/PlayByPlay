using PlayByPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayByPlay.Dtos
{
    public class GameUpdateDto
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public PlaysPage PlaysPage { get; set; }
    }
}
