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
    public class CageService : ICage<CageDto>
    {
        private readonly IRepository<Cage> repository;
        private readonly IMapper mapper;
        public CageService(IRepository<Cage> repository, IMapper map)
        {
            this.repository = repository;
            mapper = map;
        }
        public CageDto Add(CageDto item)
        {
            return mapper.Map<CageDto>(repository.Add(mapper.Map<Cage>(item)));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CageDto> GetAll()
        {
            return mapper.Map<List<CageDto>>(repository.GetAll());
        }

        public List<CageDto> GetByCageId( int[] cagesIds)
        {
            return mapper.Map<List<CageDto>>(repository.GetAll().Where(q => cagesIds.Contains(q.CageID)));
        }

        public CageDto GetById(int id)
        {
            return mapper.Map<CageDto>(repository.Get(id));
        }

        public void Update(int id, CageDto entity)
        {
            repository.Update(id, mapper.Map<Cage>(entity));
        }
    }
}
