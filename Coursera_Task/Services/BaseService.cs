using Coursera_Task.Data;

namespace Coursera_Task.Services
{
    public class BaseService
    {
        protected readonly MyDbContext _context;

        public BaseService(MyDbContext context)
        {
            _context = context;
        }
    }
}
