using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MsUsers.models.entity;
using MsUsers.Models.Dtos;

namespace MsUsers.Contracts
{
    public interface IUserController
    {
        IEnumerable<UserDTO> GetAll();

        UserDTO GetUserById(long id);

        UserDTO CreateUser(UserDTO userDTO);

        void DeleteUser();

        UserDTO UpdateUser(UserDTO userDTO);
    }
}