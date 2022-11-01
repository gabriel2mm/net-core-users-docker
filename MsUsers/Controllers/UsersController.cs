using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MsUsers.Context;
using MsUsers.Contracts;
using MsUsers.Domain.Dtos;
using MsUsers.models.entity;
using MsUsers.Models.Dtos;


namespace MsUsers.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsersController : Controller, IUserController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public StatusChangedDTO CreateUser([FromBody] UserDTO userDTO)
        {
            return this._userService.CreateUser(userDTO);
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetAll()
        {
            return this._userService.GetAll();
        }

        [HttpGet("{id}")]
        public UserDTO GetUserById(long id)
        {
            return this._userService.GetById(id);
        }

        [HttpPatch("{id}/change-status-email")]
        public StatusChangedDTO ToggleStatusEmail(long id, [FromBody] StatusDTO status)
        { 
            return this._userService.ToggleStatusEmail(id, status);
        }

        [HttpPatch("{id}/change-status")]
        public StatusChangedDTO ToggleStatusUser(long id, [FromBody]  StatusDTO status)
        {
            return this._userService.ToggleStatusUser(id, status);
        }
        
        [HttpPut("{id}")]
        public StatusChangedDTO UpdateUser(long id, [FromBody] UserDTO userDTO)
        {
            return this._userService.UpdateUser(id, userDTO);
        }
    }
}
