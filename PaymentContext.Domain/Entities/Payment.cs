using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public Payment( DateTime paidDate, 
                           DateTime expireDate, 
                           decimal total, 
                           decimal totalPaid,
                           string payer,
                           Document document, 
                           Email email, 
                           Address address)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Email = email;
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0, total, "Payment.Total", "Total can't be 0")
                );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private  set; }

        public string Payer { get; private set; }

        public Document Document { get; private set; }
        public Email Email { get; private set; }

        public Address Address { get; private set; }

    }
   
}