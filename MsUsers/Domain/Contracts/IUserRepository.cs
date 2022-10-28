using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MsUsers.models.entity;

namespace MsUsers.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {

        String GetPhoneByUserID(long userId);

    }
}