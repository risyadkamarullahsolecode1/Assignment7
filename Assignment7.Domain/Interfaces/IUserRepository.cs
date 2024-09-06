using Assignment7.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task SaveChangesAsync();
    }
}
