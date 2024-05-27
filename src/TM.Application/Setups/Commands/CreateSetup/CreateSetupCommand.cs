using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Setups;
using TM.Application.Error.Models;

namespace TM.Application.Setups.Commands
{
    public class CreateSetupCommand(SetupRequest setupRequest, ClaimsPrincipal currentUser) : IRequest<Result<InternalError, SetupResponse>>
    {
        public SetupRequest SetupRequest { get; } = setupRequest;
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;

    }
}
