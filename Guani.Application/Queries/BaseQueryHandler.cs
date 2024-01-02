using AutoMapper;
using Guani.Domain.Core;
using Microsoft.Extensions.Logging;

namespace Guani.Application.Queries
{
    public class BaseQueryHandler
    {
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;
        protected readonly Guid _currentUserId;
        protected readonly IGuaniContext _guaniContext;

        protected BaseQueryHandler(IGuaniContext guaniContext, IMapper mapper, ILogger logger)
        {
            _guaniContext = guaniContext;
            _mapper = mapper;
            _logger = logger;
            //_currentUserId = GetCurrentUserId(user);
        }

        //private static Guid GetCurrentUserId(ClaimsPrincipal user)
        //{
        //    return user.FindFirst(ClaimTypes.NameIdentifier) == null ? Guid.Empty : Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        //}
    }
}
