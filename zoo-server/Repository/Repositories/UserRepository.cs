using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IContext context;
        public UserRepository(IContext context)
        {
            this.context = context;
        }

        public User Add(User entity)
        {

            if (UserExistsWithUserName(entity.UserName))
            {

                throw new InvalidOperationException("User with the same name already exists.");

            }

            this.context.users.Add(entity);
            this.context.save();
            return entity;
        }
        private bool UserExistsWithUserName(string userName)
        {
            return this.context.users.Any(u => u.UserName == userName);
        }



        public void Delete(User entity)
        {
            this.context.users.Remove(entity);
            this.context.save();
        }
        public User Get(int id)
        {
            return this.context.users.FirstOrDefault(x => x.Id == id);

        }

        public List<User> GetAll()
        {
            return this.context.users.ToList();

        }

        public void Update(int id, User User)
        {
            User c = context.users.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                c.UserName = User.UserName;
                c.Email = User.Email;
                c.Points = User.Points;
            }

            this.context.save();
        }

    }
}
