using TM.Application.Error.Models;
using TM.Domain.Entities;

namespace TM.Application.Common.Interfaces
{
    public interface IAssetsService
    {
        Task<Result<InternalError, AssetRate>> GetAssetRateAsync(string tickerName);
    }
}
