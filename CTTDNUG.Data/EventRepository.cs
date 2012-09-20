using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using CTTDNUG.Data.Helpers;
using CTTDNUG.Model;
using Newtonsoft.Json;
using RestSharp;

namespace CTTDNUG.Data
{
    public class EventRepository:IEventRepository
    {

        public delegate void GetEventsCompleted(ObservableCollection<Event> events);

        public delegate void GetEventsErrored(string failure);

        public void GetEvents()
        {
            var client = new RestClient();
            client.BaseUrl = AppSettings.eventBriteUri;
            var request = new RestRequest();
            request.AddParameter("app_key", AppSettings.eventBriteAppKey);
            request.AddParameter("id", AppSettings.eventBriteIDforCTTDNUG);
             client.ExecuteAsync(request, (response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    success(GetCurrentEvents(response.Content));

                }
                else
                {
                    failure(response.ErrorMessage);
                }
         
            });

        }

        public event GetEventsCompleted success;
        public event GetEventsErrored failure;

        public ObservableCollection<Event> GetCurrentEvents(string events)
        {
            var response = JsonConvert.DeserializeObject<Events>(events);
                         
            var currentEvents = new ObservableCollection<Event>();

            List<Event> query = (from ev in response.events
                                 where DateTime.Parse(ev.@event.end_date) >= DateTime.Now
                                 select ev).ToList();

            query.ForEach(x => currentEvents.Add(x));
            
            return currentEvents;
        }

    }
}
