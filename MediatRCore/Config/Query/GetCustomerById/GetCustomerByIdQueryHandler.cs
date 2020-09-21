using AutoMapper;
using MediatR;
using MediatRCore.Data;
using MediatRCore.Infrastructure.Exceptions;
using MediatRCore.Models;
using MediatRCore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRCore.Query.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly CustomerContext context;

        private readonly IMapper mapper;

        public GetCustomerByIdQueryHandler(CustomerContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await context.Customers.FindAsync(request.CustomerId);

            if (customer==null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Customer with given ID is not found.");
            }
            // For testing PerformanceBehavior
          //  await Task.Delay(5000, cancellationToken);


            return mapper.Map<CustomerDto>(customer);
        }
    }
}
