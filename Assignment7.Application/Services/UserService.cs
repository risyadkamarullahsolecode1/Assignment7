using Assignment7.Application.Interfaces;
using Assignment7.Domain.Entities;
using Assignment7.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IUserRepository userRepository, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task AttachNotes(int id, string notes)
        {
            var note = await _userRepository.GetUserById(id);
            if (note == null)
            {
                throw new Exception($"user with Id {id} not found");
            }
            note.Note = notes;

            _userRepository.UpdateUser(note);
            await _userRepository.SaveChangesAsync();
        }
    }
}

