using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private readonly List<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;        
            Address = address;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name {get; private set;}

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get{ return _subscriptions.ToList(); }} 

        public void AddSubscription( Subscription subscription ){

            var hasActiveSuscription = _subscriptions.Any(s => s.Active);

            AddNotifications(new Contract()
            .Requires()
            .IsFalse(hasActiveSuscription,"Student.Subscriptions", "Student already has a subscription")
            .IsTrue(subscription.Payments.Any(),"student.subscription.Payments", "There's no payment for any subscriptions")
            );

            // if(hasActiveSuscription){
            //     AddNotification("Student.Subscriptions", "Student already has a subscription");
            // }
        }

    }
}