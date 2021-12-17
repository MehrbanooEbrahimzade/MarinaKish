using Infrastructure.Persist;

namespace Infrastructure.Repository
{
    public class BaseRepository
    {
        public BaseRepository()
        {
            
        }
        protected readonly DatabaseContext _context;
        protected BaseRepository(DatabaseContext context)
        {
            _context = context;
        }
    }
}
