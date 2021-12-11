namespace Marina_Club.Repository
{
    public class BaseRepository
    {
        protected readonly DatabaseContext _context;
        protected BaseRepository(DatabaseContext context)
        {
            _context = context;
        }
    }
}
