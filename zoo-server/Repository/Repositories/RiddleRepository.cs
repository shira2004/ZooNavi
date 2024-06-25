using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class RiddleRepository : IRepository<Riddle>
    {
        private readonly IContext context;
        public RiddleRepository(IContext context)
        {
            this.context = context;
        }

        public Riddle Add(Riddle entity)
        {
            this.context.riddles.Add(entity);
            this.context.save();
            return entity;
        }

        public void Delete(Riddle entity)
        {
            this.context.riddles.Remove(entity);
            this.context.save();
        }
        public Riddle Get(int id)
        {
            return this.context.riddles.FirstOrDefault(x => x.QuestionId == id);

        }

        public List<Riddle> GetAll()
        {
            return this.context.riddles.ToList();

        }

        public void Update(int id, Riddle Riddle)
        {
            Riddle c = context.riddles.FirstOrDefault(x => x.QuestionId == id);
            if (c != null)
            {
                c.Question = Riddle.Question;
            }

            this.context.save();
        }

    }
}
