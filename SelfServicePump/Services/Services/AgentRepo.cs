using SelfServicePump.Data;
using SelfServicePump.Entities;
using SelfServicePump.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SelfServicePump.Services.Services
{
    public class AgentRepo : IAgentRepo
    {
        private readonly PumpDbContext _context;
        public AgentRepo(PumpDbContext context)
        {
            _context = context;
        }
        public Agents AddAgent(Agents agents)
        {
            if (agents == null)
            {
                throw new ArgumentNullException(nameof(agents));
            }
            agents.AgentId = Guid.NewGuid();

            try
            {
                _context.Agents.Add(agents);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.ToString();
            }
            return agents;
        }

        public IEnumerable<Agents> GetAgentDetails()
        {
            var query = from x in _context.Agents
                        orderby x.Location
                        select x;
            return query;
        }

        public Agents GetAgentDetailsById(Guid agentId)
        {
            if (agentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(agentId));
            }
            return _context.Agents.FirstOrDefault(x => x.AgentId == agentId);
        }
    }
}