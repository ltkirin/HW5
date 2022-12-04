using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW5.Server.Business.Interfaces
{
    public interface IQuestionnairesService
    {
        Task<Response<Questionnaire>> CreateQuestionnaire(CreateQuestionnaireRequest request);
        Task<Response> DeleteQuestionnaire(int questionnaireId);
        Task<Response<Questionnaire>> GetQuestionnaireDetails(int id, bool includeOwners);
        Task<Response<IList<Questionnaire>>> GetQuestionnaires(GetListRequest request);
        Task<Response<Questionnaire>> UpdateQuestionnaire(UpdateQuestionnaireRequest request);
    }
}