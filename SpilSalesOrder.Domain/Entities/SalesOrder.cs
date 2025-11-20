using System;
using System.Collections.Generic;
using System.Text;

namespace SpilSalesOrder.Domain.Entities
{
   public class SalesOrder
    {
        public int Id { get; set; }

        public string InvoiceNo { get; set; }

        public DateOnly InvoiceDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string CustomerName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string ReferenceNo { get; set; }

        public decimal TotalExel { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalIncl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public object OrderItem { get; set; }

        public ICollection<OrderItem> OrderItemsList { get; set; }
    }
}
