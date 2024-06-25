using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<Animal> animals { get; set; }
        public DbSet<Cage> Cages { get; set ; }
      
        public DbSet<Kiosk> kiosks { get; set; }
        public DbSet<Zoo> zoos { get; set; }

        public DbSet<Ticket> tickets { get; set; }
        public DbSet<User> users { get; set; }
        //public DbSet <Role> roles { get; set; }
        public DbSet<Riddle> riddles { get; set; }

        

       
        public void save()
        {
            SaveChanges();
        }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-SSNMLFD;database=MyZoo;trusted_connection=true;");
        }

    }
}
