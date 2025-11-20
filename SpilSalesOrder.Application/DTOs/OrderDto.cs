using System;
using System.Collections.Generic;
using System.Text;

namespace SpilSalesOrder.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string InvoiceNo { get; set; }

        public DateOnly InvoiceDate { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string RefernceNo { get; set; }

        public decimal TotalExel { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalIncl { get; set; }

        public List<SalesOrderItemDto> OrderItems { get; set; }

    }

    public class SalesOrderItemDto
    {
        public int ItemId { get; set; }
        public int ItemCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalExel { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalIncl { get; set; }
    }
}
