using ASSystem.Dtos.Admin;
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

        public async Task<List<Role>> getUserRole()
        {
            return await _context.Roles.Where(r => r.RoleId != 1).ToListAsync();
        }

        // updateUserRole
        public async Task<bool> UpdateUserRole(int id, RoleDto role)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (user == null)
            {
                return false;
            }
            user.RoleId = role.RoleId;
            _context.Accounts.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUserStatus(int id, bool status)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (user == null)
            {
                return false;
            }
            user.IsActive = status;
            _context.Accounts.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            if (user == null)
            {
                return false;
            }
            if(user.IsActive == true)
            {
                user.DeleteAt = DateTime.Now;
                user.IsActive = false;
               // find all motel by user update DeleteAt = DateTime.Now
               var motels = await _context.Motels.Where(x => x.AccountId == id).ToListAsync();
                foreach (var motel in motels)
                {
                    motel.DeleteAt = DateTime.Now;
                    _context.Motels.Update(motel);
                }
            }
            else
            {
                user.DeleteAt = null;
                user.IsActive = true;
            }
            _context.Accounts.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Account> GetUserById(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
        }

        //get all motel
        public async Task<List<ASSystem.Models.Motel>> getAllMotel()
        {
            return await _context.Motels.Include(x => x.RoomImages).ToListAsync();
        }

        public async Task<List<ASSystem.Models.Motel>> getMotelByUser(int id)
        {
            return await _context.Motels.Include(x => x.RoomImages).Where(p=>p.AccountId == id).ToListAsync();
        }

        //get all role
        public async Task<List<Role>> getAllRole()
        {
            return await _context.Roles.ToListAsync();
        }

        //search user by email
        public async Task<List<Account>> GetUserByEmail(string email)
        {
            return await _context.Accounts.Where(x=> x.Username.Contains(email)).ToListAsync();
        }

        //update motel status
        public async Task<bool> UpdateMotelStatus(int id, string status)
        {
            var motel = await _context.Motels.FirstOrDefaultAsync(x => x.MotelId == id);
            if (motel == null)
            {
                return false;
            }
            motel.Status = status;
            _context.Motels.Update(motel);
            return await _context.SaveChangesAsync() > 0;
        }
        // delete motel
        public async Task<bool> DeleteMotel(int id)
        {
            var motel = await _context.Motels.FirstOrDefaultAsync(x => x.MotelId == id);
            if (motel == null)
            {
                return false;
            }
            if(motel.DeleteAt != null)
            {
                motel.DeleteAt = null;
            }
            else
            {
                motel.DeleteAt = DateTime.Now;
            }
            _context.Motels.Update(motel);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
