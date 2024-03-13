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
            return await _context.Motels.Include(x => x.RoomImages).Where(x => x.DeleteAt == null && x.Status == "Accepted").ToListAsync();
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
            return await _context.Motels.Where(x => x.AccountId == accountId && x.DeleteAt ==null).ToListAsync();
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

        // search motel by province or district or ward or price or area or tittle or all of them
        public async Task<List<ASSystem.Models.Motel>> SearchMotel(string? province, string? district, string? ward, Decimal? price, double? area, string? title)
        {
            var motels = _context.Motels.Include(x => x.RoomImages).Where(x => x.DeleteAt == null && x.Status == "Accepted");

            if (!string.IsNullOrEmpty(province))
            {
                motels = motels.Where(x => x.Province == province);
            }
            if (!string.IsNullOrEmpty(district))
            {
                motels = motels.Where(x => x.District == district);
            }
            if (!string.IsNullOrEmpty(ward))
            {
                motels = motels.Where(x => x.Ward == ward);
            }
            if (price.HasValue && price != 0)
            {
                motels = motels.Where(x => x.Price <= price);
            }
            if (area.HasValue && area != 0)
            {
                motels = motels.Where(x => x.Area <= area);
            }
            if (!string.IsNullOrEmpty(title))
            {
                motels = motels.Where(x => x.Tittle.Contains(title));
            }

            return await motels.ToListAsync();
        }

    }
}
