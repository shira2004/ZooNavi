using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class KioskRepository : IRepository<Kiosk>
    {
        private readonly IContext context;
        public KioskRepository(IContext context)
        {
            this.context = context;
        }

        public Kiosk Add(Kiosk entity)
        {
            this.context.kiosks.Add(entity);
            this.context.save();
            return entity;
        }

        public void Delete(Kiosk entity)
        {
            this.context.kiosks.Remove(entity);
            this.context.save();
        }
        public Kiosk Get(int id)
        {
            return this.context.kiosks.FirstOrDefault(x => x.KioskID == id);

        }

        public List<Kiosk> GetAll()
        {
            return this.context.kiosks.ToList();

        }

        public void Update(int id, Kiosk Kiosk)
        {
            Kiosk c = context.kiosks.FirstOrDefault(x => x.KioskID == id);
            if (c != null)
            {
                c.Name = Kiosk.Name;
            }

            this.context.save();
        }

    }
}
