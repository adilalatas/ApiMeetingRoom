using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IMeetingRepository> _bookRepository;// Nesne Kullanıldıgı zaman newlenir yoksa newlenmez
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IMeetingRepository>(()=>new MeetingRepository(_context));
        }
        IMeetingRepository IRepositoryManager.Meeting => _bookRepository.Value;

        public async Task SaveAsync()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
