using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.User.Port
{
    public interface IUserRepository
    {
        Task<IEnumerable<Entity.User>> GetList();

        Task<Entity.User> Get(string email);

        Task<Entity.User> Add(Entity.User user);

        Task<Entity.User> Update(string email, Entity.User user);

        Task<String> Delete(string email);

    }
}