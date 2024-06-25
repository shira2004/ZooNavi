using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CageRepository : IRepository<Cage>
    {
        private readonly IContext context;
        public CageRepository(IContext context)
        {
            this.context = context;
        }

        public Cage Add(Cage entity)
        {
            this.context.Cages.Add(entity);
            this.context.save();
            return entity;
        }

        public void Delete(Cage entity)
        {
            this.context.Cages.Remove(entity);
            this.context.save();
        }
        public Cage Get(int id)
        {
            return this.context.Cages.FirstOrDefault(x => x.CageID == id);

        }

        public List<Cage> GetAll()
        {
            return this.context.Cages.ToList();

        }

        public void Update(int id, Cage Cage)
        {
            Cage c = context.Cages.FirstOrDefault(x => x.CageID == id);
            if (c != null)
            {
                c.Notes = Cage.Notes;
            }

            this.context.save();
        }

    }
}
