using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TM.Application.Common.Models.Analysis;
using TM.Application.Error.Models;

namespace TM.Application.Analysis.Queries
{
    public class GetAssetsIncomeQuery(ClaimsPrincipal currentUser) : IRequest<Result<InternalError, AssetsIncomeResponse>>
    {
        public ClaimsPrincipal CurrentUser { get; set; } = currentUser;
    }
}
