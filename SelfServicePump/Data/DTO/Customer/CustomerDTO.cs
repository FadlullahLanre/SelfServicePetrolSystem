using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfServicePump.Data.DTO
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public String CustomerEmailAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CreatedAt { get; set; }
        
    }
}