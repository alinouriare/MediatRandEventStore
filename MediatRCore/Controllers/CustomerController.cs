using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatRCore.Commands;
using MediatRCore.Commands.Customers;
using MediatRCore.Config.Events;
using MediatRCore.Models.Dto;
using MediatRCore.Query.GetCustomerById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatRCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int customerId)
        {
            CustomerDto customer = await _mediator.Send(new GetCustomerByIdQuery(customerId) );
            return Ok(customer);
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            CustomerDto customer = await _mediator.Send(createCustomerCommand);

            return CreatedAtAction(nameof(GetCustomerById), new { customerId = customer.Id }, customer);
          
        }
    }
}
