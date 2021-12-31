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
    public class AgentController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IAgentRepo _agentService;

        public AgentController(IMapper mapper, IAgentRepo agentService)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));
            _agentService = agentService ??
                throw new ArgumentNullException(nameof(_agentService));

        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateAgent(AgentCreationDTO agents)
        {
            if (agents == null)
            {
                return BadRequest();
            }
            var agentEntity = _mapper.Map<Agents>(agents);
            _agentService.AddAgent(agentEntity);
            var agentToReturn = _mapper.Map<AgentDTO>(agentEntity);

            return Ok(agentToReturn);
        }
        [System.Web.Http.HttpGet()]
        [System.Web.Http.HttpHead]
        public IHttpActionResult GetAgents()
        {
            var agentFromRepo = _agentService.GetAgentDetails();
            return Ok(_mapper.Map<IEnumerable<AgentDTO>>(agentFromRepo));
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Agents/byId")]
        public IHttpActionResult GetCustomerById(Guid agentId)
        {
            var agentFromRepo = _agentService.GetAgentDetailsById(agentId);

            if (agentFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AgentDTO>(agentFromRepo));

        }
    }
}
