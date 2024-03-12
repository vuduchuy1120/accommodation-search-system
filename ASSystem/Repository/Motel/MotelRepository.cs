using ASSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ASSystem.Repository.Motel
{
    public class MotelRepository
    {
        private readonly AccommodationSearchSystemContext _context;
        public MotelRepository(AccommodationSearchSystemContext context)
        {
            _context = context;
        }

        public async Task<List<ASSystem.Models.Motel>> GetAllMotel()
        {
            return await _context.Motels.Include(x => x.RoomImages).ToListAsync();
        }

        public async Task<ASSystem.Models.Motel> GetMotelById(int id)
        {
            return await _context.Motels.FirstOrDefaultAsync(x => x.MotelId == id);
        }

        public async Task<ASSystem.Models.Motel> GetMotelByIdWithImages(int id)
        {
            return await _context.Motels.Include(p=>p.RoomImages).FirstOrDefaultAsync(x => x.MotelId == id);
        }

        public async Task<bool> CreateMotel(ASSystem.Models.Motel motel)
        {
            _context.Motels.Add(motel);
            
            return await _context.SaveChangesAsync() > 0; 
        }

        public async Task<List<ASSystem.Models.Motel>> GetMotelByAccountId(int accountId)
        {
            return await _context.Motels.Where(x => x.AccountId == accountId).ToListAsync();
        }

        public async Task<bool> CreateRoomImage(RoomImage roomImage)
        {
            _context.RoomImages.Add(roomImage);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateMotel(ASSystem.Models.Motel motel)
        {
            _context.Motels.Update(motel);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
