using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarsTest.Models
{
    public class Supp
    {
        [Key]
        public int Id { get; set; }

        [Index("ItemIndex", IsUnique = true)]
        public int SuppCode { get; set; }

        public string SuppName { get; set; }
    }
}