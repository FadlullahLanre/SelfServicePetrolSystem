using SelfServicePump.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePump.Services.Interfaces
{
    public interface IUserService
    {
        User AddCustomer(User users);
        IEnumerable<User> GetCustomerDetails();
        User GetCustomerDetailsById(Guid Id);
    }
}
