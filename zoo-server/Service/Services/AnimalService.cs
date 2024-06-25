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
    public class AnimalService : IService<AnimalDto>
    {
        private readonly IRepository<Animal> repository;
        private readonly IMapper mapper;
        public AnimalService(IRepository<Animal> repository, IMapper map)
        {
            this.repository = repository;
            mapper = map;
        }
        public AnimalDto Add(AnimalDto item)
        {
            return mapper.Map<AnimalDto>(repository.Add(mapper.Map<Animal>(item)));
        }

        public void Delete(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(mapper.Map<Animal>(entity));
        }

        public List<AnimalDto> GetAll()
        {
            return mapper.Map<List<AnimalDto>>(repository.GetAll());
        }

        public AnimalDto GetById(int id)
        {
            return mapper.Map<AnimalDto>(repository.Get(id));
        }

        public void Update(int id, AnimalDto entity)
        {
            repository.Update(id, mapper.Map<Animal>(entity));
        }

        
    }
}
