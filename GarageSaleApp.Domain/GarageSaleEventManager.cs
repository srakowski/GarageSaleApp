using System;
using System.Collections.Generic;

namespace GarageSaleApp.Domain
{
    public class GarageSaleEventManager
    {
        private readonly IGarageSaleEventRepository _eventRepository;

        public GarageSaleEventManager(IGarageSaleEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public GarageSaleEvent CreateEvent(GarageSaleEvent garageSaleEvent)
        {
            _eventRepository.Add(garageSaleEvent);    
            return garageSaleEvent;
        }

        public IEnumerable<GarageSaleEvent> GetEvents()
        {
            return _eventRepository.Events;
        }
    }
}
