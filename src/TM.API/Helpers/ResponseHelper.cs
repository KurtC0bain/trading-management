﻿using Microsoft.AspNetCore.Mvc;
using TM.Application.Common.Models;
using TM.Application.Error.Models;

namespace TM.API.Helpers
{
    internal class ResponseHelper
    {
        public static IActionResult HandleError(InternalError error)
        {
            return error switch
            {
                NotFoundError notFoundError => new NotFoundObjectResult(new ErrorResponse(notFoundError.Message, StatusCodes.Status404NotFound)),
                ValidationError validationError => new BadRequestObjectResult(new ErrorResponse(validationError.Message, StatusCodes.Status400BadRequest, errors: validationError.Errors)),
                _ => new ObjectResult(new ErrorResponse(error.Message, StatusCodes.Status500InternalServerError))
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                }
            };
        }
        public static IActionResult HandleResponse<TValue>(Result<InternalError, TValue> result)
        {
            return result.Match(
                        HandleError,
                        value => new OkObjectResult(value));
        }
    }
}
