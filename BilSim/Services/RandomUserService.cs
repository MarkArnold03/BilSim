using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;

namespace BilSim.Services
{

    public class RandomUserService : IRandomUserService
    {
        private const string RandomUserApiUrl = "https://randomuser.me/api/";

        public RandomUserApiResponse GetRandomUser()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string responseJson = client.GetStringAsync(RandomUserApiUrl).Result;
                    RandomUserApiResponse response = JsonConvert.DeserializeObject<RandomUserApiResponse>(responseJson);
                    return response;
                }
                catch (Exception ex)
                {
                    // Handle exception or log error
                    Console.WriteLine($"Error occurred while fetching random user: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
