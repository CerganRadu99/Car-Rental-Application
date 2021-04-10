using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public double TotalAmount { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}
