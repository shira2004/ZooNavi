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
    public class KioskService : IService<KioskDto>
    {
        private readonly IRepository<Kiosk> repository;
        private readonly IMapper mapper;
        public KioskService(IRepository<Kiosk> repository, IMapper map)
        {
            this.repository = repository;
            mapper = map;
        }
        public KioskDto Add(KioskDto item)
        {
            return mapper.Map<KioskDto>(repository.Add(mapper.Map<Kiosk>(item)));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<KioskDto> GetAll()
        {
            return mapper.Map<List<KioskDto>>(repository.GetAll());
        }

        public KioskDto GetById(int id)
        {
            return mapper.Map<KioskDto>(repository.Get(id));
        }

        public void Update(int id, KioskDto entity)
        {
            repository.Update(id, mapper.Map<Kiosk>(entity));
        }
    }
}
