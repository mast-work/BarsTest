using BarsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarsTest.DAL
{
    public class DeliveryRepository:IRepository<Delivery>
    {
        private BarsContext db;

        public DeliveryRepository(BarsContext context)
        {
            this.db = context;
        }

        public Delivery Get(int id)
        {
            return db.Deliveryes.Find(id);
        }

        public IEnumerable<Delivery> GetAll()
        {
            return db.Deliveryes;
        }

        public void Create(Delivery delivery)
        {
            db.Deliveryes.Add(delivery);
        }

        public void Update(Delivery delivery)
        {
            db.Entry(delivery).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int Id)
        {
            Delivery delivery = db.Deliveryes.Find(Id);

            if (delivery != null)
                db.Deliveryes.Remove(delivery);
        }

    }
}