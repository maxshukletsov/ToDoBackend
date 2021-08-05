using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.User.Entity;
using Domain.User.Port;

namespace DataAccess.Repositories
{
    public class UserRepositories : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepositories(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetList()
        {
            var userList = await _dbContext.User.ToListAsync();
            return userList;
        }

        public async Task<User> Get(string email) =>
            await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> Add(User user)
        {
            var userAdd = _dbContext.User.Add(user).Entity;
            await _dbContext.SaveChangesAsync();
            return userAdd;
        }

        public async Task<User> Update(string email, User user)
        {
            _dbContext.User.Update(user);
            await _dbContext.SaveChangesAsync();
            return await Get(email);
        }

        public async Task<String> Delete(string email)
        {
            var userDeleted = await Get(email);
            _dbContext.User.Remove(userDeleted);
            await _dbContext.SaveChangesAsync();
            return $"Пользователь {email} удален";
        }

    }
}