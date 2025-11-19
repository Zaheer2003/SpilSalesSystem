using System;
using System.Collections.Generic;
using System.Text;

namespace SpilSalesOrder.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int SalesOrderId { get; set; }

        public SalesOrder SalesOrder { get; set; }

        public int ItemCode { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TaxRate { get; set; }

        public decimal ExclAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal InclAmount { get; set; }

    }
}
