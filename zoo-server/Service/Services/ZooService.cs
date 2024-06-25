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
    public class ZooService : IService<ZooDto>
    {
        private readonly IRepository<Zoo> repository;
        private readonly IMapper mapper;
        public ZooService(IRepository<Zoo> repository, IMapper map)
        {
            this.repository = repository;
            mapper = map;
        }
        public ZooDto Add(ZooDto item)
        {
            return mapper.Map<ZooDto>(repository.Add(mapper.Map<Zoo>(item)));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ZooDto> GetAll()
        {
            return mapper.Map<List<ZooDto>>(repository.GetAll());
        }

        public ZooDto GetById(int id)
        {
            return mapper.Map<ZooDto>(repository.Get(id));
        }

        public void Update(int id, ZooDto entity)
        {
            repository.Update(id, mapper.Map<Zoo>(entity));
        }
    }
}
