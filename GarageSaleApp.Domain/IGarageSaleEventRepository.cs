using System.Collections.Generic;

namespace GarageSaleApp.Domain
{
    public interface IGarageSaleEventRepository
    {
        IEnumerable<GarageSaleEvent> Events { get; }
        void Add(GarageSaleEvent entity);
    }
}