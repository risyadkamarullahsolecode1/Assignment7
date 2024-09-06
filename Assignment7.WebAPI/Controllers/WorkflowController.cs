using Assignment7.Domain.Entities;
using Assignment7.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Assignment7.Application.Dtos.Account;

namespace Assignment7.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly WorkflowRepository _workflowRepository;

        public WorkflowController(WorkflowRepository workflowRepository)
            {
                _workflowRepository = workflowRepository;
            }

        [HttpPost]
        public async Task<ActionResult> SubmitBookRequestAsync(BookRequest requestDto, string userId)
        {
            var result = _workflowRepository.SubmitBookRequestAsync(requestDto, userId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> ApproveBookRequestAsync(ApprovalBookRequest request)
        {
            try
            {
                var result = await _workflowRepository.ApproveBookRequestAsync(
                    request.WorkflowActionId,
                    request.ProcessId,
                    request.ActorId,
                    request.Role,
                    request.IsApproved,
                    request.Comment
                    );
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
