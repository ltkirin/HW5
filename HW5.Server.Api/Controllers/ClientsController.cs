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
        [Route("details")]
        public async Task<Response<ClientFullModel>> GetClientDetails([FromQuery] int id, [FromQuery] bool includeQuestionnaires = false)
    => await clientService.GetClientDetails(id, includeQuestionnaires);
        [HttpGet]
        public async Task<Response<IList<ClientListModel>>> GetClients([FromQuery] int pageCount = 1, [FromQuery] int pageSize = 10) 
            => await clientService.GetClients(new() { PageCount = pageCount, PageSize = pageSize });
        [HttpPost]
        public async Task<Response<ClientFullModel>> CreateClient([FromForm] CreateClientRequest request) => await clientService.CreateClient(request);
        [HttpDelete]
        public async Task<Response> DeleteClient([FromQuery] int id) => await clientService.DeleteClient(id);

    }
}
