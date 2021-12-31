using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfServicePump.Entities
{
    public class Wallet

    {
        public Wallet()
        {
            TimeStamp = DateTime.Now;
        }
        [Key]
        public string CustomerID { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }


    }
}