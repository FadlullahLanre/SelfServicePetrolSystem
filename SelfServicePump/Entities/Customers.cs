using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfServicePump.Entities
{
    public class Customers
    {

        [Key]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "Email must be provided")]
        [EmailAddress]
        public String CustomerEmailAddress { get; set; }
        [Required]
        [MaxLength(14)]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
    }
}