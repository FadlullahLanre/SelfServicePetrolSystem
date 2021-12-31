using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfServicePump.Entities
{
    public class Transactions

    {
        public Transactions()
        {
            TimeStamp = DateTime.Now;
        }
        [Key]
        public string StationName { get; set; }
        [Required]
        public string StationLocation { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string Litres { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public string TransactionStatus { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        public string TransactionID { get; set; }


    }
}