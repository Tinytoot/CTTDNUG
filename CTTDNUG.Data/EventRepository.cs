using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using CTTDNUG.Model;
using RestSharp;
using System.Collections.ObjectModel;
using CTTDNUG.Data.Helpers;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CTTDNUG.Data
{
    public class EventRepository:IEventRepository
    {

        public delegate void GetEventsCompleted(List<EventBriteReponse> events);

        public delegate void GetEventsErrored(string failure);

        public void GetEvents()
        {
            var client = new RestClient();
            client.BaseUrl = AppSettings.eventBriteUri;
            var request = new RestRequest();
            request.AddParameter("app_key", AppSettings.eventBriteAppKey);
            request.AddParameter("id", AppSettings.eventBriteIDforCTTDNUG);
            client.ExecuteAsync<List<EventBriteReponse>>(request, (response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    success(response.Data);

                }
                else
                {
                    failure(response.ErrorMessage);
                }
         
            });

        }

        public event GetEventsCompleted success;
        public event GetEventsErrored failure;

    }
}
