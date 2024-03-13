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

        public async Task<bool> DeleteImages(int motel, int id)
        {
            //search images by motel id and image id if = 1 record then not delete
            var images = await _context.RoomImages.Where(x => x.MotelId == motel).ToListAsync();
            if (images.Count == 1)
            {
                return true;
            }
            var image = await _context.RoomImages.FirstOrDefaultAsync(x => x.RoomImageId == id);
            _context.RoomImages.Remove(image);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
