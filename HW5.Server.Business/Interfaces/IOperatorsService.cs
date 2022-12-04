using HW5.Contracts.Models;
using HW5.Contracts.Response;
using HW5.Server.Domain.Models;
using System.Threading.Tasks;

namespace HW5.Server.Business.Interfaces
{
    public interface IOperatorsService
    {
        Task<Response<Operator>> CreateOperator(CreateOperatorRequest command);
    }
}