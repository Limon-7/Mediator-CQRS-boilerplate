using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
	public class AuthenticationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly HttpContext httpContext;
		public AuthenticationBehaviour(IHttpContextAccessor context)
		{
			httpContext = context.HttpContext;
		}
		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			//var userId = httpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;
			if(request is BaseRequest br)
			{
				br.UserId = "Limon";
			}
			return await next();
		}
	}
}
