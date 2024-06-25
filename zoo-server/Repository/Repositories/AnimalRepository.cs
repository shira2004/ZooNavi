using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly IContext context;
        public AnimalRepository(IContext context)
        {
            this.context = context;
        }

        public Animal Add(Animal entity)
        {

            if (AnimalExistsWithName(entity.Name))
            {

                throw new InvalidOperationException("User with the same name already exists.");

            }

            this.context.animals.Add(entity);
            this.context.save();
            return entity;
        }



        private bool AnimalExistsWithName(string name)
        {
            return this.context.animals.Any(u => u.Name == name);
        }
        public void Delete(Animal entity)
        {
            this.context.animals.Remove(entity);
            this.context.save();
        }
        public Animal Get(int id)
        {
            return this.context.animals.FirstOrDefault(x => x.animalId == id);

        }

        public List<Animal> GetAll()
        {
            return this.context.animals.ToList();

        }

        public void Update(int id, Animal Animal)
        {
            Animal c = context.animals.FirstOrDefault(x => x.animalId == id);
            if (c != null)
            {
                c.Description = Animal.Description;
                c.FeedingTime = Animal.FeedingTime;
                c.Name = Animal.Name;
               // c.CageID = Animal.CageID;
            }

            this.context.save();
        }

    }
}
