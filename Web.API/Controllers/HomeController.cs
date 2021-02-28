using Application.Cars.Commands.CreateCar;
using Application.Cars.Queries.GetCars;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.API.Controllers
{
	[Route("api/cars")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public HomeController(IMediator mediator)
		{
			_mediator = mediator;
		}
		// GET: api/<HomeController>
		[HttpGet]
		public Task<IEnumerable<Car>> Get()
		{
			return _mediator.Send(new GetAllCarQuery());
		}


		// POST api/<HomeController>
		[HttpPost]
		public Task<Response<Car>> Post([FromBody] CreateCarCommand command)
		{
			return _mediator.Send(command);
		}
	}
}
