using System.Collections.Generic;
using PlayByPlay.Service.Dtos;
using PlayByPlay.Service.Models;

namespace PlayByPlay.Service
{
    public interface IGameManager
    {
        Team HomeTeam { get; set; }
        Team AwayTeam { get; set; }
        List<PlaysPage> GamePages { get; set; }
        void Start(GameUpdateDto dto);
        void Update(GameUpdateDto dto);
        GameUpdateDto LatestUpdate();
    }
}
