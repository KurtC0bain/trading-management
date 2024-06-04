using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Factors;
using TM.Application.Error.Models;

namespace TM.Application.Factors.Queries
{
    public class GetAllFactorsQuery(ClaimsPrincipal currentUser) : IRequest<Result<InternalError, List<FactorResponse>>>
    {
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
    }
}
