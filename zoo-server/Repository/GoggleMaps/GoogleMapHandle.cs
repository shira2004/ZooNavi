using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GoogleMapHandle
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("@\"https://maps.googleapis.com/maps/api/distancematrix/json?destinations=New%20York%20City%2C%20NY&origins=Washington%2C%20DC&units=imperial&key=######")

        };

      public static async Task GetAsync()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync("");

            /* response.EnsureSuccessStatusCode()
                 .WriteRequestToConsole();*/

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

        }
    }
}
