using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cars.Queries.GetCars
{
    // query
    public class GetAllCarQuery:BaseRequest,IRequest<IEnumerable<Car>>{ }

	public class GetAllCarQueryhandler : IRequestHandler<GetAllCarQuery, IEnumerable<Car>>
	{
		private readonly IApplicationDbContext _context;

		public GetAllCarQueryhandler(IApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
		{
			var car=await _context.Cars.ToListAsync();
			return await Task.FromResult(car);
		}
	}

}
