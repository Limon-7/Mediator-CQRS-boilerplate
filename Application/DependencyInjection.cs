using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped(typeof(IPipelineBehavior<,>),typeof(AuthenticationBehaviour<,>));
			services.AddMediatR(Assembly.GetExecutingAssembly());
			return services;
		}
	}
}
