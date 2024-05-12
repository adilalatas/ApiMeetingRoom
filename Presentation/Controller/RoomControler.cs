using Entitiyes.Dto;
using Entitiyes.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controller.ActionFilters;
using Services.Contracts;


namespace Presentation.Controller
{
    [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> GetAllRoom()
        {
            var Meeting =await _manager.RoomService.GetAllRooms(false);
            return Ok(Meeting);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneRoom(int id)
        {
          
            var book =await _manager.RoomService.GetOneRoomById(id, false);
            if (book is null)
                throw new MeetingFoundException(id);
            
            return Ok(book);
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
        public async Task<IActionResult> UpdateOneRoom(int id, [FromBody] RoomDto roomDto)
        {
          await  _manager.RoomService.UpdateOneRoom(id, roomDto, false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneRoom(int id)
        {
          await  _manager.RoomService.DeleteOneRoom(id, false);
            return NoContent();
        }
    }
}
