using GarageSaleApp.Domain;
using System.Collections.Generic;

namespace GarageSaleApp.DataAccess
{
    public class EFCoreGarageSaleEventRepository : IGarageSaleEventRepository
    {
        private GarageSaleAppDbContext _context;

        public EFCoreGarageSaleEventRepository()
        {
            _context = new GarageSaleAppDbContext();
        }

        public IEnumerable<GarageSaleEvent> Events => _context.GarageSaleEvents;

        public void Add(GarageSaleEvent entity)
        {
            _context.GarageSaleEvents.Add(entity);
            _context.SaveChanges();
        }
    }
}
