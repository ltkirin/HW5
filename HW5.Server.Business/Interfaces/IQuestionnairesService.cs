using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Domain.Models;
using System.Threading.Tasks;

namespace HW5.Server.Business.Interfaces
{
    public interface IQuestionnairesService
    {
        Task<Response<Questionnaire>> CreateQuestionnaire(CreateQuestionnaireRequest request);
    }
}