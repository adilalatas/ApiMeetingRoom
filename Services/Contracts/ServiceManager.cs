using AutoMapper;
using Entitiyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMeetingService> _meetingService;
        private readonly Lazy<IRoomService> _roomService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper ,UserManager<User> userManager,IConfiguration configuration)
        {
            _meetingService = new Lazy<IMeetingService>(()=> new MeetingManager(repositoryManager,logger,mapper));
            _roomService = new Lazy<IRoomService>(()=> new RoomManager(repositoryManager,logger,mapper));
            _authenticationService = new Lazy<IAuthenticationService>(()=> new AuthenticationManager(logger,mapper,userManager,configuration));
        }
        public IMeetingService MeetingService => _meetingService.Value;

        public IRoomService RoomService => _roomService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
