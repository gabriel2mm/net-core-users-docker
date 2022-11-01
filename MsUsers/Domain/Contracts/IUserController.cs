using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MsUsers.Domain.Dtos;
using MsUsers.models.entity;
using MsUsers.Models.Dtos;

namespace MsUsers.Contracts
{
    public interface IUserController
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO GetUserById(long id);
        StatusChangedDTO CreateUser(UserDTO userDTO);
        StatusChangedDTO UpdateUser(long id, UserDTO userDTO);
        StatusChangedDTO ToggleStatusUser(long id, StatusDTO status);
        StatusChangedDTO ToggleStatusEmail(long id, StatusDTO status);
    }
}