﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PeekWriterService.Models.Common.Responses;

namespace PeekWriterService.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult CustomResponse<T>(ResponseBase<T> response)
        {
            if (response.Errors != null && response.Errors.Any())
            {
                return BadRequest(new
                {
                    success = response.Success,
                    errors = response.Errors.Select(n => n)
                });
            }

            return Ok(new
            {
                success = response.Success,
                data = response.Data
            });
        }
    }
}
