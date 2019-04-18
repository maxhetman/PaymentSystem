using System;
using System.Linq;
using Data.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Filters
{
	public class ApiAuthorizeFilter : IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

			if (string.IsNullOrEmpty(authHeader)
				|| !authHeader.StartsWith("Bearer"))
			{
				context.Result = new UnauthorizedResult();
				return;
			}

			var headerKey = authHeader.Split(" ")[1];

			var dbContext = context.HttpContext.RequestServices.GetService<PaymentSystemContext>();
			if (!dbContext.SecretKeys.Any(key => key.Value == headerKey))
				context.Result = new UnauthorizedResult();
		}
	}
}
