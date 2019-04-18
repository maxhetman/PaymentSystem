using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class ApiAuthorizeAttribute : TypeFilterAttribute
	{
		public ApiAuthorizeAttribute()
			: base(typeof(ApiAuthorizeFilter))
		{
		}
	}
}
