using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayByPlay.Service;
using PlayByPlay.Service.Dtos;

namespace PlayByPlay.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PbpController : ControllerBase
    {
        public IGameManager GameManager { get; }

        public PbpController(IGameManager gameManager)
        {
            GameManager = gameManager;
        }

        [HttpGet]
        public JsonResult GetUpdate()
        {
            var latestUpdate = GameManager.LatestUpdate();
            return new JsonResult(latestUpdate);
        }

        [HttpGet("all")]
        public JsonResult GetGameInformation()
        {
            return new JsonResult(GameManager);
        }

        [HttpPost("source/start")]
        public JsonResult PostGameInformation([FromBody] GameUpdateDto dto)
        {
            GameManager.Start(dto);
            return new JsonResult("Game Updated")
            {
                StatusCode = 202 // Accepted
            };
        }

        [HttpPost("source/update")]
        public JsonResult PostUpdate([FromBody] GameUpdateDto dto)
        {
            GameManager.Update(dto);
            return new JsonResult("Game Created")
            {
                StatusCode = 201 // Created
            };
        }
    }
}
