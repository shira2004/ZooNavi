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
    public class RiddleService : IService<RiddleDto>
    {
        private readonly IRepository<Riddle> repository;
        private readonly IMapper mapper;
        public RiddleService(IRepository<Riddle> repository, IMapper map)
        {
            this.repository = repository;
            mapper = map;
        }
        public RiddleDto Add(RiddleDto item)
        {
            return mapper.Map<RiddleDto>(repository.Add(mapper.Map<Riddle>(item)));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<RiddleDto> GetAll()
        {
            return mapper.Map<List<RiddleDto>>(repository.GetAll());
        }

        public RiddleDto GetById(int id)
        {
            return mapper.Map<RiddleDto>(repository.Get(id));
        }

        public void Update(int id, RiddleDto entity)
        {
            repository.Update(id, mapper.Map<Riddle>(entity));
        }
    }
}
