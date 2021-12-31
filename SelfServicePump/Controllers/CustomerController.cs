using AutoMapper;
using SelfServicePump.Data.DTO;
using SelfServicePump.Entities;
using SelfServicePump.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SelfServicePump.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepo _customerService;

        public CustomerController(IMapper mapper, ICustomerRepo customerService)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));
            _customerService = customerService ??
                throw new ArgumentNullException(nameof(_customerService));

        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customers customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            var studentEntity = _mapper.Map<Customers>(customer);
            _customerService.AddCustomer(studentEntity);
            var studentToReturn = _mapper.Map<CustomerDTO>(studentEntity);
            return Ok(studentToReturn);
        }
        [HttpGet()]
        [HttpHead]
        public IHttpActionResult GetCustomers()
        {
            var customerFromRepo = _customerService.GetCustomerDetails();
            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(customerFromRepo));
        }
        [HttpGet]
        [Route("api/Customers/byId")]
        public IHttpActionResult GetCustomerById(String customerId)
        {
            var customerFromRepo = _customerService.GetCustomerDetailsById(customerId);

            if (customerFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDTO>(customerFromRepo));

        }
    }
}
