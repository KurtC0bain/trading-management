using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Analysis;
using TM.Application.Error.Models;

namespace TM.Application.Analysis.Queries
{
    public class GetSetupsEfficiencyQuery(ClaimsPrincipal currentUser) : IRequest<Result<InternalError, SetupsEfficiencyResponse>>
    {
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
    }
}
