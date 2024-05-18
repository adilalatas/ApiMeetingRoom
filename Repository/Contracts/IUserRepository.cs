using Entitiyes.Dto;
using Entitiyes.Models;
using Entitiyes.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        Task<User> GetOneUserById(Guid id,bool trackChanges);
        void UpdateOneUser(User user);
    }
}
