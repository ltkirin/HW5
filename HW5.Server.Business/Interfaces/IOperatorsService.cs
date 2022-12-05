using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW5.Server.Business.Interfaces
{
    public interface IOperatorsService
    {
        Task<Response<OperatorFullModel>> CreateOperator(CreateOperatorRequest request);
        Task<Response> DeleteOperator(int operatorId);
        Task<Response<OperatorFullModel>> GetOperatorDetails(int id, bool includeReposrts);
        Task<Response<IList<OperatorListModel>>> GetOperators(GetListRequest request);
        Task<Response<OperatorFullModel>> UpdateOperator(UpdateOperatorRequest request);
    }
}