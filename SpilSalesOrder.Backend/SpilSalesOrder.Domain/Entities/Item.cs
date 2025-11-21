using System;
using System.Collections.Generic;
using System.Text;

namespace SpilSalesOrder.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public int ItemCode { get; set; }

        public string Description { get; set; }

        public string? Note { get; set; }

        public decimal Price { get; set; }

        public decimal TaxRate { get; set; }


    }
}
