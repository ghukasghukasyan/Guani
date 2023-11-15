using AutoMapper;
using Guani.Domain.Core;
using Microsoft.Extensions.Logging;

namespace Guani.Application.Commands
{
    public abstract class BaseCommandHandler
    {
        protected readonly IGuaniContext _guaniContext;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        protected BaseCommandHandler(IGuaniContext guaniContext, IMapper mapper, ILogger logger)
        {
            _guaniContext = guaniContext;
            _logger = logger;
            _mapper = mapper;

        }
    }
}
