using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema; // Import for [ForeignKey]

namespace SpilSalesOrder.Domain.Entities
{
    public class SalesOrderItem
    {
        public int Id { get; set; }

        public int SalesOrderId { get; set; }

        public SalesOrder SalesOrder { get; set; }

        public int ItemId { get; set; } // Change from ItemCode to ItemId
        [ForeignKey("ItemId")] // Configure ItemId as foreign key
        public Item Item { get; set; } // Navigation property

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TaxRate { get; set; }

        public decimal ExclAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal InclAmount { get; set; }

    }
}
