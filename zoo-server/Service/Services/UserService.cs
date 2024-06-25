using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IService<UserDto>
    {
        private readonly IRepository<User> repository;
        private readonly IMapper mapper;
        public UserService(IRepository<User> repository, IMapper map)
        {
            this.repository = repository;
            mapper = map;
        }
        public UserDto Add(UserDto item)
        {
            item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
            return mapper.Map<UserDto>(repository.Add(mapper.Map<User>(item)));
        }

        public void Delete(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(mapper.Map<User>(entity));
        }

    
        public List<UserDto> GetAll()
        {
            return mapper.Map<List<UserDto>>(repository.GetAll());
        }

        public UserDto GetById(int id)
        {
            return mapper.Map<UserDto>(repository.Get(id));
        }

        public void Update(int id, UserDto entity)
        {
            repository.Update(id, mapper.Map<User>(entity));
        }
    }
}
