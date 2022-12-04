using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Business.Interfaces;
using HW5.Server.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }
        [HttpGet]
        [Route("/details")]
        public async Task<Response<Client>> GetClientDetails([FromQuery] int id, [FromQuery] bool includeQuestionnaires = false)
    => await clientService.GetClientDetails(id, includeQuestionnaires);
        [HttpGet]
        public async Task<Response<IList<Client>>> GetOperators([FromQuery] GetListRequest request) => await clientService.GetClients(request);
        [HttpPost]
        public async Task<Response<Client>> CreateOperator([FromForm] CreateClientRequest request) => await clientService.CreateClient(request);
        [HttpDelete]
        public async Task<Response> CreateOperator([FromQuery] int id) => await clientService.DeleteClient(id);

    }
}
