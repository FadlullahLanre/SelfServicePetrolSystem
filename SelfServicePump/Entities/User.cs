using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfServicePump.Entities
{
    public class User
    {
        public User()
        {
            CreatedAt = DateTime.Now;

        }



        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string CardId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Email must be provided")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

    }
}
