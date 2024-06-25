using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ZooRepository : IRepository<Zoo>
    {
        private readonly IContext context;
        public ZooRepository(IContext context)
        {
            this.context = context;
        }

        public Zoo Add(Zoo entity)
        {
            this.context.zoos.Add(entity);
            this.context.save();
            return entity;
        }

        public void Delete(Zoo entity)
        {
            this.context.zoos.Remove(entity);
            this.context.save();
        }
        public Zoo Get(int id)
        {
            //GetAsyncmap();
            return this.context.zoos.FirstOrDefault(x => x.ZooID == id);

        }

        public List<Zoo> GetAll()
        {
            return this.context.zoos.ToList();

        }

        public void Update(int id, Zoo Zoo)
        {
            Zoo c = context.zoos.FirstOrDefault(x => x.ZooID == id);
            if (c != null)
            {
                c.Name = Zoo.Name;
            }

            this.context.save();
        }

        //private static HttpClient sharedClient = new()
        //{
        //    BaseAddress = new Uri("https://maps.googleapis.com/maps/api/distancematrix/json?destinations=New%20York%20City%2C%20NY&origins=Washington%2C%20DC&units=imperial&key=#####")

        //};

        //private static async Task GetAsyncmap()
        //{
        //    using HttpResponseMessage response = await sharedClient.GetAsync("");

        //    /* response.EnsureSuccessStatusCode()
        //         .WriteRequestToConsole();*/

        //    var jsonResponse = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine($"{jsonResponse}\n");

        //}
    }
}
