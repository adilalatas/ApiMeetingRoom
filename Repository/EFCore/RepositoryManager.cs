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
        private readonly Lazy<IRoomRepository> _roomRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IMeetingRepository>(()=>new MeetingRepository(_context));
            _roomRepository = new Lazy<IRoomRepository>(()=>new RoomRepository(_context));
        }
        IMeetingRepository IRepositoryManager.Meeting => _bookRepository.Value;
        IRoomRepository IRepositoryManager.Room => _roomRepository.Value;

        public async Task SaveAsync()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
