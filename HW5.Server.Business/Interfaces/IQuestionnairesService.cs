using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW5.Server.Business.Interfaces
{
    public interface IQuestionnairesService
    {
        Task<Response<QuestionnaireFullModel>> CreateQuestionnaire(CreateQuestionnaireRequest request);
        Task<Response> DeleteQuestionnaire(int questionnaireId);
        Task<Response<QuestionnaireFullModel>> GetQuestionnaireDetails(int id, bool includeOwners);
        Task<Response<IList<QuestionnaireListModel>>> GetQuestionnaires(GetListRequest request);
        Task<Response<QuestionnaireFullModel>> UpdateQuestionnaire(UpdateQuestionnaireRequest request);
    }
}