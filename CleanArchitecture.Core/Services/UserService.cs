using CleanArchitecture.Core.Entities;
using CleanArchitecture.SharedKernel.Interfaces;

namespace CleanArchitecture.Core.Services
{
    public class UserService
    {
        private readonly IRepository<User> userRepo;

        public UserService(IRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<User> CreateUserAsync(string name, string password, string? email)
        {
            var u = new User
            {
                Active = true,
                Deleted = false,
                Email = email,
                EmailConfirmed = false,
                Name = name,
                RegisterDate = DateTime.UtcNow,
                PasswordHash = password,
            };
            return await userRepo.AddAsync(u);
        }
    }
}
