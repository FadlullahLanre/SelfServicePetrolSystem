using SelfServicePump.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Services.Interfaces
{
    public interface ICustomerRepo
    {
        Customers AddCustomer(Customers customers);
        IEnumerable<Customers> GetCustomerDetails();
        Customers GetCustomerDetailsById(string email);
    }
}