using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using AutoMapper;
using MsUsers.Contracts;
using MsUsers.Domain.Dtos;
using MsUsers.Domain.Exceptions;
using MsUsers.models.entity;
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

        public StatusChangedDTO CreateUser(UserDTO userDTO)
        {
            User user = this._mapper.Map<User>(userDTO);
            user.UserActive = true;
            user.EmailVerified = false;

            this._repository.Add(user);
            this._repository.SaveAll();

            return new StatusChangedDTO("success", "user created");
        }

        public List<UserDTO> GetAll()
        {
            var users = _repository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public UserDTO GetById(long id)
        {
            User? user = this._repository.Get(user => user.Id == id).FirstOrDefault();
            if (user == null)
                 throw new NotFoundException("User not found", "User not found");
            

            return _mapper.Map<UserDTO>(user);
        }

        public StatusChangedDTO ToggleStatusEmail(long id, StatusDTO status)
        {
            User? user = this._repository.Get(user => user.Id == id).FirstOrDefault();
            if (user != null) {
                user.EmailVerified = status.Status;
                this._repository.Update(user);
                this._repository.SaveAll();
                return new StatusChangedDTO("success", "Email activate changed!");
            }

            throw new NotFoundException("E-mail activate failure, please contract the administrator.");
        }

        public StatusChangedDTO ToggleStatusUser(long id, StatusDTO status)
        {
            User? user = this._repository.Get(user => user.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.EmailVerified = status.Status;
                this._repository.Update(user);
                this._repository.SaveAll();
                return new StatusChangedDTO("success", "user activate changed!");
            }
            throw new NotFoundException("User activate failure, please contract the administrator.");
        }

        public StatusChangedDTO UpdateUser(long id, UserDTO userDTO)
        {
            User? user = this._repository.Get(user => user.Id == id).FirstOrDefault();
            if (user != null)
            {
                User userFromDTO = this._mapper.Map<User>(userDTO);
                userFromDTO.Id = user.Id;

                this._repository.Update(userFromDTO);
                this._repository.SaveAll();
                return new StatusChangedDTO("success", "user updated");
            }
            throw new NotFoundException("User updated failure, please contract the administrator.");
        }
    }
}