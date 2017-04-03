using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarsTest.Models
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateDelivery { get; set; }

        public virtual Item Item { get; set; }

        public virtual Supp Supp { get; set; }
    }
}