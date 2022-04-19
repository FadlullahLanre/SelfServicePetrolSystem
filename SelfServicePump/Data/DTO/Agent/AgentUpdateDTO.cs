using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Data.DTO.Agent
{
    public class AgentUpdateDTO
    {
        public string AgentEmailAddress { get; set; }
        public double AgentEarnings { get; set; }
        public string CompanyName { get; set; }
        public bool IsApproved { get; set; }
        public string DateApproved { get; set; }
        public string Location { get; set; }
        public string BankName { get; set; }
        public string Hotline { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
    }
}