using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fights.Core.Repositories.Comments;
using Fights.Data.Entities;

namespace Fights.Api.Controllers
{
    [Route("api/protests")]
    public class CommentController : BaseController
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentController(
            ICommentRepository commentRepository,
            IMapper mapper
        ) {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        [HttpGet("{protestId}/comments")]
        public ActionResult<IEnumerable<Comment>> GetByProtest(long protestId)
        {
            var comments = this.commentRepository.GetByProtest(protestId);
            return Ok(comments);
        }
        
    }
}