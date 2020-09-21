using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRCore.Config.Events
{
    public class CustomerCreatedEvent:INotification
    {
        public CustomerCreatedEvent(string firstName, string lastName, string registrationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            RegistrationDate = registrationDate;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string RegistrationDate { get; }
    }
}
