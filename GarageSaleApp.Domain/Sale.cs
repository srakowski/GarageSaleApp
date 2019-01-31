using System;
using System.Collections.Generic;

namespace GarageSaleApp.Domain
{
    public class Sale
    {
        public GarageSaleEvent Event { get; set; }

        public ICollection<SaleLineItem> LineItems { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
