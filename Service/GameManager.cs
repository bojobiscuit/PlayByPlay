using System.Collections.Generic;
using System.Linq;
using PlayByPlay.Service.Dtos;
using PlayByPlay.Service.Models;

namespace PlayByPlay.Service
{
    public class GameManager : IGameManager
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public List<PlaysPage> GamePages { get; set; }

        public void Start(GameUpdateDto dto)
        {
            HomeTeam = dto.HomeTeam;
            AwayTeam = dto.AwayTeam;
            GamePages = new List<PlaysPage>();
        }

        public void Update(GameUpdateDto dto)
        {
            HomeTeam = dto.HomeTeam;
            AwayTeam = dto.AwayTeam;

            if (dto.PlaysPage != null)
            {
                GamePages.Add(dto.PlaysPage);
                GamePages = GamePages.OrderBy(a => a.Page).ToList();
            }
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
