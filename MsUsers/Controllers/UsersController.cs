using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MsUsers.Context;
using MsUsers.Contracts;
using MsUsers.models.entity;
using MsUsers.Models.Dtos;


namespace MsUsers.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller, IUserController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetAll()
        {
            return this._userService.GetAll();
        }

        public UserDTO CreateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }


        public UserDTO GetUserById(long id)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
