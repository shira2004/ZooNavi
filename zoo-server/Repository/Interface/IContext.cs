using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IContext
    {

        public DbSet<Cage> Cages { get; set; }
        public DbSet<Animal> animals { get; set; }
        public DbSet<Kiosk> kiosks { get; set; }
        public DbSet<Ticket> tickets { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Zoo> zoos { get; set; }
        public DbSet<Riddle> riddles { get; set; }

        //object Response { get; set; }

        public void save();

    }
}
