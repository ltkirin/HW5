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
    public class OperatorsController : ControllerBase
    {
        private readonly IOperatorsService operatorsService;

        public OperatorsController(IOperatorsService operatorsService)
        {
            this.operatorsService = operatorsService;
        }

        [HttpGet]
        [Route("api/[controller]/details")]
        public async Task<Response<Operator>> GetOperatorDetails([FromQuery] int id, [FromQuery] bool includeQuestionnaires = false) => await operatorsService.GetOperatorDetails(id, includeQuestionnaires);
        [HttpGet]
        public async Task<Response<IList<Operator>>> GetOperators([FromQuery]GetListRequest request) => await operatorsService.GetOperators(request);
        [HttpPost]
        public async Task<Response<Operator>> CreateOperator([FromForm]CreateOperatorRequest request) => await operatorsService.CreateOperator(request);
        [HttpDelete]
        public async Task<Response> CreateOperator([FromQuery] int id) => await operatorsService.DeleteOperator(id);
    }
}
