using System;
using System.Collections.Generic;
using System.Text;

namespace SpilSalesOrder.Domain.Entities
{
    public class Customer
    { 
        public int id { get; set; }

        public string CustomerName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
