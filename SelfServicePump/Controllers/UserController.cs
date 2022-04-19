using AutoMapper;
using SelfServicePump.Data.DTO;
using SelfServicePump.Entities;
using SelfServicePump.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SelfServicePump.Controllers
{
    [System.Web.Http.Route("api/customers")]
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));
            _userService = userService ??
                throw new ArgumentNullException(nameof(_userService));

        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomer(UserCreationDTO customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            var studentEntity = _mapper.Map<User>(customer);
            _userService.AddCustomer(studentEntity);
            var studentToReturn = _mapper.Map<UserDTO>(studentEntity);
            return Ok(studentToReturn);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.HttpHead]
        public IHttpActionResult GetCustomers()
        {
            var customerFromRepo = _userService.GetCustomerDetails();
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(customerFromRepo));
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/customers/byId")]
        public IHttpActionResult GetCustomerById(Guid Id)
        {
            var customerFromRepo = _userService.GetCustomerDetailsById(Id);

            if (customerFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDTO>(customerFromRepo));

        }
    }
}
