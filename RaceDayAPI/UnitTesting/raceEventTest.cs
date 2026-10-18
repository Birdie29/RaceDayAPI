using Xunit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.UnitTesting
{
    public class raceEventTest
    {
        [Fact]
        public void OrganiserCreatesEvent()
        {
            var createEvent = new createEvent
            {
                eventID = 1001,
                eventName = "Marathon",
                eventDate = DateTime.Now.AddDays(30),
                location = "Johannesburg",
                distance = 42.195,
                organiserId = 1
            };

            var eventName = createEvent.eventName;
            Assert.Equal("Marathon", eventName);
        }

        [Fact]
        public void OrganiserViewsEvent()
        {
            var eventView = new eventView
            {
                eventID = 1002,
                eventName = "Marathon",
                eventDate = DateTime.Now.AddDays(30),
                location = "City Park",
                distance = 42.195,
                organiserId = 2
            };
          
            var eventName = eventView.eventName;

            Assert.Equal("Marathon", eventName);
        }

        [Fact]
        public void OrganiserUpdatesEvent()
        {
            var eventUpdate = new eventUpdate
            {
                eventID = 1003,
                eventName = "Marathon",
                eventDate = DateTime.Now.AddDays(30),
                location = "City Park",
                distance = 5.0, 
                organiserId = 3
            };
           
            eventUpdate.distance = 10.0;

            Assert.Equal(10.0, eventUpdate.distance);
        }

        [Fact]
        public void OrganiserDeletesEvent()
        {
            var eventDelete = new eventDelete
            {
                eventID = 1004,
                eventName = "Marathon",
                eventDate = DateTime.Now.AddDays(30),
                location = "City Park",
                distance = 42.195,
                organiserId = 4
            };
          
            eventDelete.RemoveAll(e => e.eventID == 1004);

            Assert.Empty(eventDelete);
        }
    }
}