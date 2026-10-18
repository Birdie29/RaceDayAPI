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
                eventID = 301,
                eventName = "Soweto Marathon",
                eventDate = DateTime.Now.AddDays(30),
                location = "Johannesburg",
                distance = 42.195,
                organiserId = 101
            };

            var result = await _controller.Create(createEvent);
            Assert.IsType<CreatedActionResult>(result);
            Assert.Equal("Soweto Marathon", result.eventName);
        }

        [Fact]
        public void InvalidEventCreation()
        {
            var eventView = new eventView
            {
                eventID = 301,
                eventName = "Swimming Competition",
                eventDate = DateTime.Now.AddDays(30),
                location = " ",
                distance = 42.195,
                organiserId = 101
            };
          
          _controller.ModelState.AddModelError("location", "Location is required.");
            var result = await_controller.Create(eventView);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void OrganiserUpdatesEvent()
        {
            var eventUpdate = new eventUpdate
            {
                eventID = 302,
                eventName = "Two Oceans",
                eventDate = DateTime.Now.AddDays(30),
                location = "Cape Town",
                distance = 5.0, 
                organiserId = 101
            };
           
            var result = await _controller.Update(eventUpdate.eventID, eventUpdate);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void InvalidEventUpdate()
        {
            var eventUpdate = new eventUpdate
            {
                eventID = 302,
                eventName = " ",
                eventDate = DateTime.Now.AddDays(30),           
        location = "Cape Town",
                distance = 5.0, 
                organiserId = 101
            };
          
            _controller.ModelState.AddModelError("eventName", "Event name is required.");
            var result = await _controller.Update(eventUpdate.eventID, eventUpdate);

            
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void OrganiserDeletesEvent()
        {
            var eventDelete = new eventDelete
            {
                eventID = 301,
                eventName = "Marathon",
                eventDate = DateTime.Now.AddDays(30),
                location = "City Park",
                distance = 42.195,
                organiserId = 1003
            };
          
            eventDelete.RemoveAll(e => e.eventID == 301);

            Assert.Empty(eventDelete);
        }

        [Fact]
        public void InvalidEventDeletion()
        {
            var eventDelete = new eventDelete
            {
                eventID = 302,
                eventName = " ",
                eventDate = DateTime.Now.AddDays(30),
                location = "City Park",
                distance = 42.195,
                organiserId = 1003
            };
            _controller.ModelState.AddModelError("eventName", "Event name is required.");
            var result = await _controller.Delete(eventDelete.eventID);
            
            Assert.IsType<NotFoundObjectResult>(result);
        }
}