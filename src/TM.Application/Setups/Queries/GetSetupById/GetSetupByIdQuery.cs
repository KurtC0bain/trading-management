using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Setups;
using TM.Application.Error.Models;

namespace TM.Application.Setups.Queries
{
    public class GetSetupByIdQuery(string setupId, ClaimsPrincipal currentUser) : IRequest<Result<InternalError, SetupResponse>>
    {
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
        public string SetupId { get; } = setupId;
    }
}
