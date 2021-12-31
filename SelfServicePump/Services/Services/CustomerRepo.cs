using SelfServicePump.Data;
using SelfServicePump.Entities;
using SelfServicePump.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Services.Services
{
    public class CustomerRepo : ICustomerRepo
    {

        private readonly PumpDbContext _context;
        public CustomerRepo(PumpDbContext context)
        {
            _context = context;
        }
        public Customers AddCustomer(Customers customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            try
            {
                _context.Customers.Add(customers);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.ToString();
            }
            return customers;
        }

        public IEnumerable<Customers> GetCustomerDetails()
        {
            var query = from x in _context.Customers
                        orderby x.CustomerId
                        select x;
            return query;
        }

        public Customers GetCustomerDetailsById(string customerId)
        {
            if (customerId == string.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }
            return _context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        }
    }
}