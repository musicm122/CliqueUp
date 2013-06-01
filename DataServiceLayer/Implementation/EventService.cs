using System;
using System.Collections.Generic;
using System.Linq;
using CliqueUpModel.Model;
using CliqueUpModel.Contract;


namespace CliqueUpModel.Implementation
{
    public class EventService : IEventService
    {
        public Event CreateEvent(string title, string description, IEnumerable<string> categories, System.DateTime start, System.DateTime end, decimal lat, decimal lon)
        {

            var newEvent = new Event()
                {
                    Id = Guid.NewGuid(),

                };

            throw new System.NotImplementedException();
        }

        public bool OpenEvent(System.Guid userId, System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public bool CloseEvent(System.Guid userId, System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetCategories(CliqueUpContext cliqueUpContext, IEnumerable<string> categories)
        {
            return categories.Select(category => GetOrCreateCategoryIfNotExists(cliqueUpContext, category));
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
