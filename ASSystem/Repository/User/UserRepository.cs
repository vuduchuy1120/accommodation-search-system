using ASSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ASSystem.Repository.User
{
    public class UserRepository
    {
        private readonly AccommodationSearchSystemContext _context;
        public UserRepository(AccommodationSearchSystemContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Account account)
        {
            _context.Accounts.Add(account);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsUserIdExist(int id)
        {
            return await _context.Accounts.AnyAsync(x => x.AccountId == id);
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _context.Accounts.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> IsUsernameExist(string username)
        {
            return await _context.Accounts.AnyAsync(x => x.Username == username);
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
        }
        // getall
        public async Task<List<Account>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Accounts.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        // getUserByID
        public async Task<Account> GetUserByID(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
        }
        // getUserByEmail
        public async Task<Account> GetUserByEmail(string email)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
        }
        // getUserByUsername
        public async Task<Account> GetUserByUsername(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Username == username);
        }
        // update

        public async Task<bool> Update(Account account)
        {
            _context.Accounts.Update(account);
            return await _context.SaveChangesAsync() > 0;
        }
        // update password
        public async Task<bool> UpdatePassword(string email, string password)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
            account.Password = password;
            _context.Accounts.Update(account);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsPhoneExist(string? phone)
        {
            return await _context.Accounts.AnyAsync(x => x.Phone == phone);
        }
    }
}
