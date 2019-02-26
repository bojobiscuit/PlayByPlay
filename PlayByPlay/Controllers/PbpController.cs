using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayByPlay.Dtos;
using PlayByPlay.Models;

namespace PlayByPlay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PbpController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUpdate()
        {
            if (_game == null)
                return GameNotSet();

            var latestUpdate = _game.LatestUpdate();
            return new JsonResult(latestUpdate);
        }

        [HttpGet("all")]
        public JsonResult GetGameInformation()
        {
            if (_game == null)
                return GameNotSet();

            return new JsonResult(_game);
        }

        [HttpPost("source/start")]
        public JsonResult PostGameInformation([FromBody] GameUpdateDto dto)
        {
            lock (_game)
                _game = new Game(dto);

            return new JsonResult("Game Updated")
            {
                StatusCode = 202 // Accepted
            };
        }

        [HttpPost("source/update")]
        public JsonResult PostUpdate([FromBody] GameUpdateDto dto)
        {
            if (_game == null)
                return GameNotSet();

            _game.Update(dto);
            return new JsonResult("Game Created")
            {
                StatusCode = 201 // Created
            };
        }

        private JsonResult GameNotSet()
        {
            return new JsonResult("Game not set")
            {
                StatusCode = 200 // OK
            };
        }

        private static Game _game;
    }
}
