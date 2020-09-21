using AutoMapper;
using MediatR;
using MediatRCore.Config.Events;
using MediatRCore.Data;
using MediatRCore.Models;
using MediatRCore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRCore.Commands.Customers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        readonly CustomerContext context;
        readonly IMapper mapper;
        readonly IMediator mediator;

        public CreateCustomerCommandHandler(CustomerContext context,
            IMapper mapper,
            IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = mapper.Map<Customer>(request);


            await context.Customers.AddAsync(customer, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            //test tranaction
           // throw new Exception("======= MY CUSTOM EXCEPTION =======");


            // Raising Event ...
             await mediator.Publish(new CustomerCreatedEvent(customer.FirstName, customer.LastName, customer.RegistrationDate.ToString()));

            return mapper.Map<CustomerDto>(customer);
        }
    }
}
