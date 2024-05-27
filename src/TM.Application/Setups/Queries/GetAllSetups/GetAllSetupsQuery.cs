using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Setups;
using TM.Application.Error.Models;

namespace TM.Application.Setups.Queries
{
    public class GetAllSetupsQuery(ClaimsPrincipal currentUser) : IRequest<Result<InternalError, List<SetupResponse>>>
    {
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
    }
}
