﻿using Microsoft.AspNetCore.Http;
using Pukimoni.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pukimoni.Implementation.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            var errorDetails = new ErrorDetails();

            errorDetails.Message = ex.Message;
            // Kada se desi greska, ovaj middleware sluzi da uhvati, ubaci lepo u error dto detalje i prikaze to kao response.
            switch (ex)
            {
                case UnauthorizedException unauthorizedException:
                    errorDetails.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case NotFoundException notFoundException:
                    errorDetails.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case FluentValidation.ValidationException validationException:
                    errorDetails.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    errorDetails.Errors = validationException.Errors.Select(x => new { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage });
                    break;
                case Application.Exceptions.ValidationException customValidationException:
                    errorDetails.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    errorDetails.Errors = customValidationException.Failures;
                    break;
                default:
                    errorDetails.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetails.Message = "Internal Server Error, please contact your administrator!";
                    break;
            }

            context.Response.StatusCode = errorDetails.StatusCode;
            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
