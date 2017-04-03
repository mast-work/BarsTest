using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarsTest.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set;}

        [Index("ItemIndex",IsUnique = true)]
        public int ItemCode { get; set; }

        public string ItemDesc { get; set; }
    }
}