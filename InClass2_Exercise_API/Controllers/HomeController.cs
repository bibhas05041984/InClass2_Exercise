using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using InClass2_Exercise_API.Models;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace InClass2_Exercise_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        HttpClient httpClient;

        static string BASE_URL = "https://developer.nps.gov/api/v1/";
        static string API_KEY = "36KAHyxFO1wZnsVtYITsJNm3pCLeSoUalsdo6aSx"; // Bibhas Key
        public IActionResult Index()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string NATIONAL_PARK_API_PATH = BASE_URL + "/parks?limit=10";
            string parksData = "";

            Parks parks = null;

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!parksData.Equals(""))
                {
                    
                    parks = JsonConvert.DeserializeObject<Parks>(parksData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message  
                Console.WriteLine(e.Message);
            }

            return View(parks);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MyLink()
        {
            return View();
        }
        /*public IActionResult UserAction(PersonModel person)
        {
            
            string name = person.Name;
            string city = person.City;
            string gender = person.Attending;

            return View();
        }*/

        [HttpGet]
        public ViewResult UserAction()
        {
            return View();
        }

        [HttpPost]
        public ViewResult UserAction(PersonModel person)
        {
            PersonModel.AddResponse(person);
            return View("UserActionResponse", person);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



