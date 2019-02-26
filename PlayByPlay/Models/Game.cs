using PlayByPlay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayByPlay.Models
{
    public class Game
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public List<PlaysPage> GamePages { get; set; }

        public Game(GameUpdateDto dto)
        {
            HomeTeam = dto.HomeTeam;
            AwayTeam = dto.AwayTeam;
            GamePages = new List<PlaysPage>();
        }

        public void Update(GameUpdateDto dto)
        {
            HomeTeam = dto.HomeTeam;
            AwayTeam = dto.AwayTeam;
            GamePages.Add(dto.PlaysPage);
            GamePages = GamePages.OrderBy(a => a.Page).ToList();
        }

        public GameUpdateDto LatestUpdate()
        {
            return new GameUpdateDto()
            {
                HomeTeam = HomeTeam,
                AwayTeam = AwayTeam,
                PlaysPage = GamePages.Last()
            };
        }
    }
}
