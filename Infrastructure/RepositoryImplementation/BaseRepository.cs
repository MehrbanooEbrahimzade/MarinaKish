using Infrastructure.Persist;

namespace Infrastructure.RepositoryImplementation
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
