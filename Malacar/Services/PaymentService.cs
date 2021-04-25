using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Malacar.Services
{
    public class PaymentService : BaseService
    {
        public PaymentService(IRepositoryWrapper RepositoryWrapper) : base(RepositoryWrapper)
        {

        }

        public List<Payment> GetPayments()
        {
            return RepositoryWrapper.PaymentRepository.FindAll().ToList();
        }

        public List<Payment> GetPaymentsByCondition(Expression<Func<Payment, bool>> expression)
        {
            return RepositoryWrapper.PaymentRepository.FindByCondition(expression).ToList();
        }

        public void AddPayment(Payment Payment)
        {
            RepositoryWrapper.PaymentRepository.Create(Payment);
        }

        public void UpdatePayment(Payment Payment)
        {
            RepositoryWrapper.PaymentRepository.Update(Payment);
        }

        public void DeletePayment(Payment Payment)
        {
            RepositoryWrapper.PaymentRepository.Delete(Payment);
        }

    }
}
