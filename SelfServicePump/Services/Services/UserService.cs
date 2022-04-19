using SelfServicePump.Data;
using SelfServicePump.Entities;
using SelfServicePump.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Services.Services
{
    public class UserService :  IUserService
    {
        private readonly PumpDbContext _context;
        public UserService(PumpDbContext context)
        {
            _context = context;
        }

        public User AddCustomer(User users)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            users.UserId = Guid.NewGuid();
            try
            {
                _context.Users.Add(users);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.ToString();
            }
            return users;
        }

        public IEnumerable<User> GetCustomerDetails()
        {
            var query = from x in _context.Users
                        orderby x.EmailAddress
                        select x;
            return query;
        }

        public User GetCustomerDetailsById(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            return _context.Users.FirstOrDefault(x => x.UserId == Id);
        }
    }
}
