using Entitiyes.Models;
using Entitiyes.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void UpdateOneUser(User user) => Update(user);
        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges) => await FindAll(trackChanges).OrderBy(x => x.Id).ToListAsync();

        public async Task<User> GetOneUserById(Guid id, bool trackChanges) =>await FindByConddition(x=>x.Id.Equals(id),trackChanges).SingleOrDefaultAsync();


      
       
    }
}
