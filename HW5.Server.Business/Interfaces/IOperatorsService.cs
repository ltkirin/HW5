﻿using HW5.Contracts.Models;
using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW5.Server.Business.Interfaces
{
    public interface IOperatorsService
    {
        Task<Response<Operator>> CreateOperator(CreateOperatorRequest command);
        Task<Response> DeleteOperator(int operatorId);
        Task<Response<IList<Operator>>> GetOperators(GetListRequest request);
    }
}