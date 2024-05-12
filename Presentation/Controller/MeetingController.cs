using Entitiyes.Dto;
using Entitiyes.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controller.ActionFilters;
using Services.Contracts;


namespace Presentation.Controller
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/Meeting")]
    public class MeetingController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public MeetingController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeetingAsync()
        {
            var Meeting =await _manager.MeetingService.GetAllMeetings(false);
            return Ok(Meeting);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneBook(int id)
        {
          
            var book =await _manager.MeetingService.GetOneMeetingById(id, false);
            if (book is null)
                throw new BookNotFoundException(id);
            
            return Ok(book);
        }
  
       
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBook([FromBody] MeetingDto meetingDto)
        {
           await _manager.MeetingService.CreateOneMeeting(meetingDto);
            return StatusCode(201, meetingDto);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneBook(int id, [FromBody] MeetingDto meetingDto)
        {
          await  _manager.MeetingService.UpdateOneMeeting(id, meetingDto, false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneBook(int id)
        {
          await  _manager.MeetingService.DeleteOneMeeting(id, false);
            return NoContent();
        }
    }
}
