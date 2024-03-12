using ASSystem.Dtos;
using ASSystem.Exceptions;
using ASSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ASSystem.Repository.Auth
{
    public class AuthRepository
    {
        private readonly AccommodationSearchSystemContext _context;

        public AuthRepository(AccommodationSearchSystemContext context)
        {
            _context = context;
        }

        public async Task<Account> Login(string email, string password)
        {
            Account user = await _context.Accounts.FirstOrDefaultAsync(x => x.Email.Trim() == email.Trim() && x.Password == password);
            return user;
        }
    }
}
