using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Data.DTO
{
    public class UserCreationDTO
    {
        public string CardId { get; set; }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}