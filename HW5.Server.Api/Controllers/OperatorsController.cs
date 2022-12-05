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
        [Route("details")]
        public async Task<Response<OperatorFullModel>> GetOperatorDetails([FromQuery] int id, [FromQuery] bool includeQuestionnaires = false) 
            => await operatorsService.GetOperatorDetails(id, includeQuestionnaires);
        [HttpGet]
        public async Task<Response<IList<OperatorListModel>>> GetOperators([FromQuery] int pageCount = 1, [FromQuery] int pageSize = 10)
            => await operatorsService.GetOperators(new() { PageCount = pageCount, PageSize = pageSize });
        [HttpPost]
        public async Task<Response<OperatorFullModel>> CreateOperator([FromForm] CreateOperatorRequest request) => await operatorsService.CreateOperator(request);
        [HttpDelete]
        public async Task<Response> CreateOperator([FromQuery] int id) => await operatorsService.DeleteOperator(id);

    }
}
