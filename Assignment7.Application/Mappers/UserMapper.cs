using Assignment7.Application.Dtos;
using Assignment7.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Position = user.Position,
                Previlege = user.Previlege
            };
        }
    }
}
