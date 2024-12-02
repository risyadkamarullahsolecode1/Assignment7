using Assignment7.Application.Dtos;
using Assignment7.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment7.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookRequestController : ControllerBase
    {
        private readonly IBookRequestService _bookRequestService;

        public BookRequestController(IBookRequestService bookRequestService)
        {
            _bookRequestService = bookRequestService;
        }
        [Authorize]
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitBookRequest(BookRequestDto bookRequestDto)
        {
            var res = await _bookRequestService.SubmitJobPostRequest(bookRequestDto);
            return Ok(res);
        }

        [Authorize(Roles = "Librarian,Library Manager")]
        [HttpPost("review")]
        public async Task<IActionResult> ReviewBookRequest(ReviewRequestDto reviewRequestDto)
        {
            var res = await _bookRequestService.ReviewJobPostRequest(reviewRequestDto);
            return Ok(res);
        }
    }
}
