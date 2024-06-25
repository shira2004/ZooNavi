using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly IContext context;
        public TicketRepository(IContext context)
        {
            this.context = context;
        }

        public Ticket Add(Ticket entity)
        {
            this.context.tickets.Add(entity);
            this.context.save();
            return entity;
        }

        public void Delete(Ticket entity)
        {
            this.context.tickets.Remove(entity);
            this.context.save();
        }
        public Ticket Get(int id)
        {
            return this.context.tickets.FirstOrDefault(x => x.TicketID == id);

        }

        public List<Ticket> GetAll()
        {
            return this.context.tickets.ToList();

        }

        public void Update(int id, Ticket Ticket)
        {
            Ticket c = context.tickets.FirstOrDefault(x => x.TicketID == id);
            if (c != null)
            {
                c.price = Ticket.price;
            }

            this.context.save();
        }

    }
}
