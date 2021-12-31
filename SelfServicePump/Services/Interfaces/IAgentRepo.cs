using SelfServicePump.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Services.Interfaces
{
    public interface IAgentRepo
    {
        Agents AddAgent(Agents agents);
        IEnumerable<Agents> GetAgentDetails();
        Agents GetAgentDetailsById(Guid email);
    }
}