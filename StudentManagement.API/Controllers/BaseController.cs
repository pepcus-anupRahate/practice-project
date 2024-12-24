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
                        return result.StatusCode switch
                        {
                            StatusCodes.Status200OK => Ok(result.Result),
                            StatusCodes.Status201Created => Created("", result.Result),
                            _ => NoContent(),
                        };
                    }
                    else
                    {
                        return NoContent();
                    }
                }
                else
                {
                    return result.StatusCode switch
                    {
                        StatusCodes.Status400BadRequest => BadRequest(result.Message),
                        StatusCodes.Status401Unauthorized => Unauthorized(result.Message),
                        StatusCodes.Status403Forbidden => Forbid(result.Message),
                        StatusCodes.Status404NotFound => NotFound(result.Message),
                        StatusCodes.Status500InternalServerError => HandleException(result.Exception),
                        _ => BadRequest(result.Message),
                    };
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
