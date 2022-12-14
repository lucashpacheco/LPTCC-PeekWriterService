using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.PeekWriter.Commands;
using PeekWriterService.Models.Common;

namespace PeekWriterService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikesController : ControllerBase
    {

        private readonly ILogger<PeekController> _logger;
        private readonly ICommandHandler _commandHandler;


        public LikesController(ILogger<PeekController> logger, ICommandHandler commandHandler)
        {
            _logger = logger;
            _commandHandler = commandHandler;
        }

        [HttpPost]
        public async Task<ResponseBase<bool>> Create([FromBody] CreateLikeCommand createPeekCommand)
        {
            var result = await _commandHandler.Create(createPeekCommand);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseBase<bool>> Delete([FromQuery] DeleteLikeCommand deleteCommentCommand)
        {
            var result = await _commandHandler.Delete(deleteCommentCommand);

            return result;
        }
    }
}
