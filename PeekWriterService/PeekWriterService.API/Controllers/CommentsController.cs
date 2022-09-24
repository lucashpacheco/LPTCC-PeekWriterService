using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeekWriterService.Models.Commands;
using PeekWriterService.Models.Common.Responses;

namespace PeekWriterService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
       
        private readonly ILogger<PeekController> _logger;

        public CommentsController(ILogger<PeekController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ResponseBase<bool> Create([FromQuery] CreatePeekCommand createPeekCommand)
        {
            return null;
        }

        [HttpPut]
        public ResponseBase<bool> Update([FromQuery] UpdateCommentCommand updateCommentCommand)
        {
            return null;
        }

        [HttpDelete]
        public ResponseBase<bool> Delete([FromQuery] DeleteCommentCommand deleteCommentCommand)
        {
            return null;
        }
    }
}
