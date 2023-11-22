using Guani.Domain.Entities;
using Guani.Domain.Entities.Enum;

namespace Guani.Domain.Rules
{
    public interface IAsyncRule
    {
        Task<bool> IsBroken();
        string Message { get; }
        ErrorCode ErrorCode { get; }
    }
}
