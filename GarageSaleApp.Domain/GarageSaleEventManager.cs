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

        public GarageSaleEvent CreateEvent(
            string name,
            DateTime startDate,
            DateTime endDate,
            string notes)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name must not be empty");
            }

            var @event = new GarageSaleEvent
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Notes = notes
            };

            _eventRepository.Add(@event);
    
            return @event;
        }

        public IEnumerable<GarageSaleEvent> GetEvents()
        {
            return _eventRepository.Events;
        }
    }
}
