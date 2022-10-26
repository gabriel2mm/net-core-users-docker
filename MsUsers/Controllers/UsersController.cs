using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MsUsers.Context;
using MsUsers.models.entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MsUsers.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserContext _userContext;

        public UsersController([FromServices] UserContext userContext)
        {
            _userContext = userContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userContext.Users;
        }

        [HttpGet("/teste")]
        public String GetTeste()
        {
            return "Teste";
        }


    }
}
