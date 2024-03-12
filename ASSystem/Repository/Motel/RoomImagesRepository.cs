using ASSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ASSystem.Repository.Motel
{
    public class RoomImagesRepository
    {
        private readonly AccommodationSearchSystemContext _context;
        public RoomImagesRepository(AccommodationSearchSystemContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteImages(int id)
        {
            var images = await _context.RoomImages.Where(x => x.RoomImageId == id).ToListAsync();
            if (images.Count == 0)
            {
                return true;
            }
            _context.RoomImages.RemoveRange(images);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
