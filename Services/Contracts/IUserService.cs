using Entitiyes.Dto;
using Entitiyes.DTO;
using Entitiyes.Models;
using Entitiyes.RequestFeatures;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers(bool trackChanges);
        Task<UserDto> GetOneUserById(Guid id, bool trackChanges);
        Task UpdateOneUser(Guid id, User user, bool trackChanges);

   
    }
}
