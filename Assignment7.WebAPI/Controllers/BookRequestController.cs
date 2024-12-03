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
        private readonly IWebHostEnvironment _environment;

        public BookRequestController(IBookRequestService bookRequestService, IWebHostEnvironment environment)
        {
            _bookRequestService = bookRequestService;
            _environment = environment;
        }
        [Authorize(Roles = "Library User")]
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
        [Authorize(Roles = "Library User,Librarian,Library Manager")]
        [HttpGet("status")]
        public async Task<IActionResult> GetBookRequestStatus()
        {
            try
            {
                var statuses = await _bookRequestService.GetAllBookRequestStatuses();
                return Ok(statuses);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                long MaxFileSize = 2 * 1024 * 1024; // 2MB
                string[] AllowedFileTypes = new[] {
            "application/pdf",
            "application/msword",
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        };

                if (file == null || file.Length == 0)
                    return BadRequest("File is empty");

                if (file.Length > MaxFileSize)
                    return BadRequest("File size exceeds 2MB limit");

                if (!AllowedFileTypes.Contains(file.ContentType))
                    return BadRequest("Only PDF and Word documents are allowed");

                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save file to directory
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Ok("File uploaded succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{processId}")]
        public async Task<IActionResult> GetProcess(int processId)
        {
            var res = await _bookRequestService.GetProcessAsync(processId);
            return Ok(res);
        }
    }
}
