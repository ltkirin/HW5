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
    public class QuestionairesController : ControllerBase
    {

        private readonly IQuestionnairesService questionnairesService;

        public QuestionairesController(IQuestionnairesService questionnairesService)
        {
            this.questionnairesService = questionnairesService;
        }

        [HttpGet]
        [Route("details")]
        public async Task<Response<QuestionnaireFullModel>> GetQuestionnaireDetails([FromQuery] int id, [FromQuery] bool includeOwners = false)
            => await questionnairesService.GetQuestionnaireDetails(id, includeOwners);
        
        [HttpGet]
        public async Task<Response<IList<QuestionnaireListModel>>> GetQuestionnaires([FromQuery] int pageCount = 1, [FromQuery] int pageSize = 10) 
            => await questionnairesService.GetQuestionnaires(new() {PageCount = pageCount, PageSize = pageSize });

        [HttpPost]
        public async Task<Response<QuestionnaireFullModel>> CreateQuestionnaire(CreateQuestionnaireRequest request) => await questionnairesService.CreateQuestionnaire(request);
        [HttpDelete]
        public async Task<Response> DeleteQuestionnaire(int id) => await questionnairesService.DeleteQuestionnaire(id);
    }
}
