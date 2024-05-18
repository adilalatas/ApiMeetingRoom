using Entitiyes.Dto;
using Entitiyes.Exceptions;
using Entitiyes.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controller.ActionFilters;
using Services.Contracts;
using System.Text.Json;


namespace Presentation.Controller
{
    //[Authorize]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/Room")]
    public class RoomControler : ControllerBase
    {
        private readonly IServiceManager _manager;
        public RoomControler(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllRoom()
        {
            var Meeting =await _manager.RoomService.GetAllRoom(false);
            return Ok(Meeting);
        }
            
        [HttpGet("page")]
        public async Task<IActionResult> GetAllRoomPage([FromQuery] RoomParameters roomParameters)
        {
            var res =await _manager.RoomService.GetAllRoomPage(roomParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(res.metaData));
            return Ok(res.rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneRoom(Guid id)
        {
          
            var room =await _manager.RoomService.GetOneRoomById(id, false);
            if (room is null)
                throw new Exception("Toplantı Odası Bulunamadı");
            
            return Ok(room);
        }
  
       
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneRoom([FromBody] RoomDto roomDto)
        {
           await _manager.RoomService.CreateOneRoom(roomDto);
            return StatusCode(201, roomDto);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneRoom(Guid id, [FromBody] RoomDto roomDto)
        {
          await  _manager.RoomService.UpdateOneRoom(id, roomDto, false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneRoom(Guid id)
        {
          await  _manager.RoomService.DeleteOneRoom(id, false);
            return NoContent();
        }
    }
}
