using Entitiyes.Dto;
using Entitiyes.Exceptions;
using Entitiyes.Models;
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
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var Meeting =await _manager.UserService.GetAllUsers(false);
            return Ok(Meeting);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUserById(Guid id)
        {
          
            var user =await _manager.UserService.GetOneUserById(id, false);
            if (user is null)
                throw new Exception("Kullanıcı Bulunamadı");
            
            return Ok(user);
        }
     
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneUser(Guid id, [FromBody] User user)
        {
          await  _manager.UserService.UpdateOneUser(id, user, false);
            return NoContent();
        }

    }
}
