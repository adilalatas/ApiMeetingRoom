using AutoMapper;
using Entitiyes.Dto;
using Entitiyes.DTO;
using Entitiyes.Exceptions;
using Entitiyes.Models;
using Entitiyes.RequestFeatures;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public UserManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }



        public async Task<IEnumerable<UserDto>> GetAllUsers(bool trackChanges)
        {
            var user = await _manager.User.GetAllUsers(trackChanges);
            return _mapper.Map<IEnumerable<UserDto>>(user); 
         
        }   


        public async Task<UserDto> GetOneUserById(Guid id, bool trackChanges)
        {
            var user = await _manager.User.GetOneUserById(id,trackChanges);
            return _mapper.Map<UserDto>(user);

        }

        public async Task UpdateOneUser(Guid id, User user, bool trackChanges)
        {
              await GetOneUserAndCheck(id, trackChanges);

            _manager.User.UpdateOneUser(user);
              await  _manager.SaveAsync();

        }
        private async Task<User> GetOneUserAndCheck(Guid id, bool trackChanges){
            var entity = await _manager.User.GetOneUserById(id, trackChanges);
            if (entity is null)
                throw new Exception("Kullanıcı Bulunamadı");

            return entity;

        }
    }
}
