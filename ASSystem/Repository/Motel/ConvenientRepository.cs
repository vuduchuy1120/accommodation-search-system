using ASSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ASSystem.Repository.Motel
{
    public class ConvenientRepository
    {
        private readonly AccommodationSearchSystemContext _context;
        public ConvenientRepository(AccommodationSearchSystemContext context)
        {
            _context = context;
        }

        public async Task<List<ASSystem.Models.Convenient>> GetAllConvenient()
        {
            return await _context.Convenients.ToListAsync();
        }

        public async Task<ASSystem.Models.Convenient> GetConvenientById(int id)
        {
            return await _context.Convenients.FirstOrDefaultAsync(x => x.ConvenientId == id);
        }

       
    }
}
