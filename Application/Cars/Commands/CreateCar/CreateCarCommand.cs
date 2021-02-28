using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cars.Commands.CreateCar
{
    public class CreateCarCommand : IRequest<Response<Car>>
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Response<Car>>

    {
        private readonly IApplicationDbContext _context;

        public CreateCarCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                Name = request.Name,
                Title = request.Title
            };
            _context.Cars.Add(car);
            var success = await _context.SaveChangesAsync(cancellationToken);
            if (success > 0)
                return await Task.FromResult(Response.Ok<Car>(car, "Created Successfully"));
            return await Task.FromResult(Response.Fail<Car>("Already exists"));
        }
    }
}
