using System.Collections.Generic;

namespace GarageSaleApp.Domain
{
    public class Party
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GarageSaleEventParty> GarageSalesEventParties { get; set; }
    }
}
