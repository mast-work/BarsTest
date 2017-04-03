using BarsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarsTest.DAL
{
    public class SuppRepository:IRepository<Supp>
    {
        private BarsContext db;

        public SuppRepository(BarsContext context)
        {
            this.db = context;
        }

        public Supp Get(int id)
        {
            return db.Supps.Find(id);
        }

        public IEnumerable<Supp> GetAll()
        {
            return db.Supps;
        }

        public void Create(Supp supp)
        {
            db.Supps.Add(supp);
        }

        public void Update(Supp supp)
        {
            db.Entry(supp).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int Id)
        {
            Supp supp = db.Supps.Find(Id);

            if (supp != null)
                db.Supps.Remove(supp);
        }
    }
}