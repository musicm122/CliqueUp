﻿using System;
using System.Collections.Generic;
using System.Linq;
using CliqueUpModel.Model;
using CliqueUpModel.Contract;
using DataServiceLayer.Helper;
using Models.Model;

namespace DataServiceLayer.Implementation
{
    public class EventService : IEventService
    {
        public Event CreateEvent(string title, string description, IEnumerable<string> categories, DateTime start, DateTime end, double lat, double lon)
        {
            var dbContext = new CliqueUpContext();
            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                Categories = GetCategories(dbContext, categories),
                CreateOn = DateTime.Now,
                Description = description,
                Title = title,
                StartTime = start,
                EndTime = end,
                Latitude = lat,
                Longitude = lon,
                IsActive = true,
                DisabledOn = null,
            };

            dbContext.Events.Add(newEvent);
            dbContext.SaveChanges();
            return newEvent;
        }

        public bool OpenEvent(Guid userId, Guid eventId)
        {

            throw new NotImplementedException();
        }

        public bool CloseEvent(Guid userId, Guid eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> SearchEvents(string searchQuery, double baseLatitude, double baseLongitude, int searchRadiusMiles)
        {
            searchQuery = searchQuery == null ? null : searchQuery.Trim().ToLower();
            var splitCategories = searchQuery == null ? 
                null : searchQuery.Split(' ').Select(s => s.Trim()).Where(s => s.StartsWith("#"));

            var dbContext = new CliqueUpContext();
            var events = 
               (from e in dbContext.Events.Include("Categories")
                where searchQuery == null || e.Description.Contains(searchQuery)
                where splitCategories == null || e.Categories.Any(c => splitCategories.Any(sc => sc == c.Description))
                select e)
                .ToList()
                .Where(e => searchRadiusMiles >= GeoMath.Distance(baseLatitude, baseLongitude, e.Latitude, e.Longitude, GeoMath.MeasureUnits.Miles));

            return events;
        }

        public EventMessage PostEventMessage(Guid userid, Guid eventId, string messageText)
        {
            var dbContext = new CliqueUpContext();
            var newMessage = new EventMessage
            {
                Id = Guid.NewGuid(),
                UserId = userid,
                EventId = eventId,
                Text = messageText
            };

            dbContext.EventMessages.Add(newMessage);
            dbContext.SaveChanges();

            return newMessage;
        }

        public List<Category> GetCategories(CliqueUpContext cliqueUpContext, IEnumerable<string> categories)
        {
            return categories.Select(category => GetOrCreateCategoryIfNotExists(cliqueUpContext, category)).ToList();
        }

        public Category GetOrCreateCategoryIfNotExists(CliqueUpContext cliqueUpContext, string category)
        {
            category = category.Trim().ToLower();
            var dbCategory = cliqueUpContext
                .EventCategories
                .SingleOrDefault(eventCategory => eventCategory.Description == category);

            if (dbCategory == null)
            {
                dbCategory = new Category()
                    {
                        Id = Guid.NewGuid(),
                        Description = category
                    };
                cliqueUpContext.EventCategories.Add(dbCategory);
                // We should do this AFTER retrieving everything so we can keep
                // all the creations in a single transaction.
                cliqueUpContext.SaveChanges(); 
            }

            return dbCategory;
        }
    }
}
