using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Common.Models.Setups;
using TM.Application.Error.Models;

namespace TM.Application.Setups.Commands
{
    public class UpdateSetupCommand(SetupRequest setupRequest, string id, ClaimsPrincipal currentUser) : IRequest<Result<InternalError, SetupResponse>>
    {
        public SetupRequest SetupRequest { get; set; } = setupRequest;
        public string SetupId { get; set; } = id;
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
    }
}
