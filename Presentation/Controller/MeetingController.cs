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
    [Authorize]
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

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMeeting()
        {
            var Meeting =await _manager.MeetingService.GetAllMeetings(false);
            return Ok(Meeting);
        }
        [HttpGet("page")]
        public async Task<IActionResult> GetAllMeetingPage([FromQuery] MeetingParameters meetingParameters)
        {
            var res = await _manager.MeetingService.GetAllMeetingsPage(meetingParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(res.metaData));
            return Ok(res.meetings);
        }

        [HttpGet("roomId")]
        public async Task<IActionResult> GetAllMeetingRoomId(Guid id)
        {
          
            var meeting =await _manager.MeetingService.GetAllMeetingRoomId(id, false);
            if (meeting is null)
                throw new MeetingFoundException();
            
            return Ok(meeting);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetAllMeetingUserId(string id)
        {

            var meeting = await _manager.MeetingService.GetAllMeetingUserId(id, false);
            if (meeting is null)
                throw new MeetingFoundException();

            return Ok(meeting);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneMeetingById(Guid id)
        {

            var meeting = await _manager.MeetingService.GetOneMeetingById(id, false);
            if (meeting is null)
                throw new MeetingFoundException();

            return Ok(meeting);
        }


        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneMeeting([FromBody] MeetingDto meetingDto)
        {
           await _manager.MeetingService.CreateOneMeeting(meetingDto);
            return StatusCode(201, meetingDto);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneMeeting(Guid id, [FromBody] MeetingDto meetingDto)
        {
          await  _manager.MeetingService.UpdateOneMeeting(id, meetingDto, false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneMeeting(Guid id)
        {
          await  _manager.MeetingService.DeleteOneMeeting(id, false);
            return NoContent();
        }
    }
}
