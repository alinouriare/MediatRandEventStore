using MediatR;
using MediatRCore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRCore.Query.GetCustomerById
{
    public class GetCustomerByIdQuery:IRequest<CustomerDto>
    {

        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get;  }
    }
}
