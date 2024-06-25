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
    public class TicketService : IService<TicketDto>
    {
        private readonly IRepository<Ticket> repository;
        private readonly IMapper mapper;
        public TicketService(IRepository<Ticket> repository, IMapper map)
        {
            this.repository = repository;
            mapper = map;
        }
        public TicketDto Add(TicketDto item)
        {
            return mapper.Map<TicketDto>(repository.Add(mapper.Map<Ticket>(item)));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TicketDto> GetAll()
        {
            return mapper.Map<List<TicketDto>>(repository.GetAll());
        }

        public TicketDto GetById(int id)
        {
            return mapper.Map<TicketDto>(repository.Get(id));
        }

        public void Update(int id, TicketDto entity)
        {
            repository.Update(id, mapper.Map<Ticket>(entity));
        }
    }
}
