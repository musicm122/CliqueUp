using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliqueUpModel.Model;

namespace CliqueUpModel.Contract
{
    interface IEventService
    {
        /// <summary>
        /// Creates an event
        /// </summary>
        /// <param name="title">Title of the event</param>
        /// <param name="description">Description of the event</param>
        /// <param name="categories">List of categories tied to this event</param>
        /// <param name="start">Expected start time of the event</param>
        /// <param name="end">Expected end time of the event</param>
        /// <param name="lat">Approximate latitude of the event</param>
        /// <param name="lon">Approximate longitude of the event</param>
        /// <returns>Event object created.</returns>
        Event CreateEvent(string title, string description, IEnumerable<string> categories, DateTime start, DateTime end, double lat, double lon);
        
        /// <summary>
        /// Marks an event as active
        /// </summary>
        /// <param name="userId">The ID of the user opening the event</param>
        /// <param name="id">The ID of the event</param>
        /// <returns>boolean denoting whether the event was opened successfully or not</returns>
        bool OpenEvent(Guid userId, Guid id);

        /// <summary>
        /// Marks an event as closed
        /// </summary>
        /// <param name="userId">The ID of the user closing the event</param>
        /// <param name="id">The ID of the event</param>
        /// <returns>boolean denoting whether the event was closed successfully or not</returns>
        bool CloseEvent(Guid userId, Guid id);

        /// <summary>
        /// Finds all events matching search parameters
        /// </summary>
        /// <param name="searchQuery">Search query that looks over title and description and categories.  Categories
        /// are space delimited and start with # character</param>
        /// <param name="baseLatitude"></param>
        /// <param name="baseLongitude"></param>
        /// <param name="searchRadiusMiles"></param>
        /// <returns></returns>
        IEnumerable<Event> SearchEvents(string searchQuery, double baseLatitude, double baseLongitude, int searchRadiusMiles);

        EventMessage PostEventMessage(Guid userid, Guid eventId, string messageText);
    }
}
