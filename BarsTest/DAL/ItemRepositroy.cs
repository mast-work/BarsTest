using BarsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarsTest.DAL
{

    public class ItemRepository : IRepository<Item>
    {
        private BarsContext db;

        public ItemRepository(BarsContext context)
        {
            this.db = context;
        }

        public Item Get(int id)
        {
            return db.Items.Find(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Items;
        }

        public void Create(Item item)
        {
            db.Items.Add(item);
        }

        public void Update(Item item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int Id)
        {
            Item item = db.Items.Find(Id);

            if (item != null)
                db.Items.Remove(item);
        }


    }
}