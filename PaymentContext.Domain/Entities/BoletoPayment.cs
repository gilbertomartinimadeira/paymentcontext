using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        
        public BoletoPayment(DateTime paidDate, 
                             DateTime expireDate, 
                             decimal total, 
                             decimal totalPaid, 
                             string payer,
                             Document document,
                             Email email, 
                             Address address, 
                             string barCode, 
                             string boletoNumber) : base (paidDate, expireDate,total, totalPaid,payer,document, email, address)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
        
        

    }
}