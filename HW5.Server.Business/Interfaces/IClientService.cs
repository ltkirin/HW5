using HW5.Contracts.Request;
using HW5.Contracts.Response;
using HW5.Server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Business.Interfaces
{
    public interface IClientService
    {
        Task<Response<Client>> CreateClient(CreateClientRequest command);
    }
}
