using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfServicePump.Entities
{
    public class Agents
    {

        public Agents()
        {
            DateApproved = DateTime.Today;
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }


        [Key]
        public Guid AgentId { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email Address must be provided")]
        public string AgentEmailAddress { get; set; }
        public double AgentEarnings { get; set; }
        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; }
        public bool IsApproved { get; set; }
        [Required]
        public DateTime DateApproved { get; set; }
        [Required]
        [MaxLength(250)]
        public string Location { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string Hotline { get; set; }
        [Required]
        public string BankAccountName { get; set; }
        [Required]
        public string BankAccountNumber { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
    }
}