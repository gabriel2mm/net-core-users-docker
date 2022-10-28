using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MsUsers.Context;
using MsUsers.Contracts;
using MsUsers.models.entity;

namespace MsUsers.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PostgresContext context) : base(context){}

        public string GetPhoneByUserID(long userId)
        {
            throw new NotImplementedException();
        }
    }
}