using MediatR;
using System.Security.Claims;
using TM.Application.Common.Models.Setups;
using TM.Application.Error.Models;

namespace TM.Application.Setups.Commands
{
    public class DeleteSetupCommand(string setupId, ClaimsPrincipal currentUser) : IRequest<Result<InternalError, SetupResponse>>
    {
        public string SetupId { get; set; } = setupId;
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
    }

}
