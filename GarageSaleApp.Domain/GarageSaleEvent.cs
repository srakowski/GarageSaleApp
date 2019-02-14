using System;
using System.Collections.Generic;

namespace GarageSaleApp.Domain
{
    public class GarageSaleEvent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Notes { get; set; }

        public ICollection<GarageSaleEventParty> GarageSaleEventParties { get; set; }

        public ICollection<Sale> Sales { get; set; }        
    }
}
