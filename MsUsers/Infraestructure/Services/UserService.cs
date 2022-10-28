using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MsUsers.Contracts;
using MsUsers.Models.Dtos;

namespace MsUsers.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;


        public UserService(IUserRepository repository, IMapper mapper){
            _mapper = mapper;
            _repository = repository;
        }

        public List<UserDTO> GetAll()
        {
            var users = _repository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}