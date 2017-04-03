using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace BarsTest.DAL
{
    public class UnitOfWork:IDisposable
    {
        private BarsContext db = new BarsContext();
        private ItemRepository itemRerository;
        private SuppRepository suppRepository;
        private DeliveryRepository deliveryRepository;


        #region Exception

        List<int> TryDecodeDbUpdateException(DbUpdateException ex)
        {
            var result =new List<int>();
            if (!(ex.InnerException is System.Data.Entity.Core.UpdateException) ||
                !(ex.InnerException.InnerException is System.Data.SqlClient.SqlException))
                 result = null;
            var sqlException =
                (System.Data.SqlClient.SqlException)ex.InnerException.InnerException;

            for (int i = 0; i < sqlException.Errors.Count; i++)
            {
                result.Add(sqlException.Errors[i].Number);
            }

            return result;
        }

        #endregion

        public ItemRepository Items
        {
            get
            {
                if (itemRerository == null)
                {
                    itemRerository = new ItemRepository(db);
                }
                return itemRerository;
            }
        }

        public SuppRepository Supps
        {
            get
            {
                if (suppRepository == null)
                {
                    suppRepository = new SuppRepository(db);
                }
                return suppRepository;
            }
        }

        public DeliveryRepository Deliveryes
        {
            get
            {
                if (deliveryRepository == null)
                {
                    deliveryRepository = new DeliveryRepository(db);
                }
                return deliveryRepository;
            }
            
        }



        public List<int> Save()
        {
            
            try
            {
                db.SaveChanges();
                return null;
            }

            catch (DbUpdateException ex)
            {
                var decodedErrors = TryDecodeDbUpdateException(ex);
                if (!decodedErrors.Contains(2601))
                    throw;  //it isn't something we understand so rethrow
                return decodedErrors;
            }
            //else it isn't an exception we understand so it throws in the normal way

            
        }



        private bool dispoused = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.dispoused)
            {
                if (disposing)
                {
                    db.Dispose();
                    this.dispoused = true;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}