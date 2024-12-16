using Microsoft.AspNetCore.Mvc;
using StudentManagement.Entities;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleResponse<T>(BaseResult<T> result, string? successMessage = null)
            where T : class
        {
            if (result is not null)
            {
                if (!result.IsError)
                {
                    if (result.Result is not null)
                    {
                        switch (result.StatusCode)
                        {
                            case StatusCodes.Status200OK:
                                return Ok(result.Result);
                            case StatusCodes.Status201Created:
                                return Created("", result.Result);
                            default:
                                return NoContent();
                        }
                    }
                    else
                    {
                        return NoContent();
                    }
                }
                else
                {
                    switch (result.StatusCode)
                    {
                        case StatusCodes.Status400BadRequest:
                            return BadRequest(result.Message);

                        case StatusCodes.Status401Unauthorized:
                            return Unauthorized(result.Message);

                        case StatusCodes.Status403Forbidden:
                            return Forbid(result.Message);

                        case StatusCodes.Status404NotFound:
                            return NotFound(result.Message);

                        case StatusCodes.Status500InternalServerError:
                            return HandleException(result.Exception);

                        default:
                            return BadRequest(result.Message);
                    }
                }
            }
            else
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred on the server. Please try again later."
                );
            }
        }

        protected IActionResult HandleException(Exception ex)
        {
            _logger.LogError(ex.Message, "An error occurred while processing the request.");
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "An error occurred on the server. Please try again later."
            );
        }
    }
}
