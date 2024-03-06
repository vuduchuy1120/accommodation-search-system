using ASSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ASSystem.Repository.Admin
{
    public class AdminRepository
    {
        private readonly AccommodationSearchSystemContext _context;

        public AdminRepository(AccommodationSearchSystemContext context)
        {
            _context = context;
        }
        // getAllUser
        public async Task<List<Account>> GetAllUser()
        {
            return await _context.Accounts.ToListAsync();
        }
    }
}
