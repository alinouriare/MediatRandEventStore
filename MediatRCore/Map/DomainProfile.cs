using AutoMapper;
using MediatRCore.Commands;
using MediatRCore.Commands.Customers;
using MediatRCore.Models;
using MediatRCore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRCore.Map
{
    public class DomainProfile:Profile
    {

        public DomainProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(c => c.RegistrationDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.RegistrationDate, opt => opt.MapFrom(c => c.RegistrationDate.ToShortDateString()));
                
        }
    }
}
