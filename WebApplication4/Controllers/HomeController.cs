using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        string BASE_URL = "https://api.fda.gov/drug/enforcement.json";
        HttpClient httpClient;

        public HomeController(IRepository repository)
        {
            _repository = repository;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Recall> GetRecalls(string country, string state, string catclass, string typeofrecall)
        {
            if (country == null)
            {
                country = "united";
            }
            if (state==null)
            {
                state = "ca";
            }
            if (catclass == null)
            {
                catclass = "i";
            }
            if (typeofrecall == "food")
            {
                BASE_URL = "https://api.fda.gov/food/enforcement.json";
            }

            
            //string Foodrecall_API = BASE_URL + "?search=report_date:[20040101+TO+20131231]&limit=10";
            //string Foodrecall_API = BASE_URL + "ref-data/symbols";
            string recalllist = "";
            List<Recall> samples = null;

            //httpClient.BaseAddress = new Uri(Foodrecall_API);
            //HttpResponseMessage response = httpClient.GetAsync(Foodrecall_API).GetAwaiter().GetResult();

            string querystring = "?search=country:"+country+"&limit=10";
            string Foodrecall_API1 = BASE_URL + querystring;

            httpClient.BaseAddress = new Uri(Foodrecall_API1);
            HttpResponseMessage response = httpClient.GetAsync(Foodrecall_API1).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                recalllist = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                //string results = recalllist.Substring(700, 2671);
            }

            if (!recalllist.Equals(""))
            {
                JObject recallJson = JObject.Parse(recalllist);
                //JObject resultsObject = (JObject)recallJson["results"];
                JArray resultsArray = (JArray)recallJson["results"];
                string resultsString = resultsArray.ToString();
                samples = JsonConvert.DeserializeObject<List<Recall>>(resultsString);
                //samples = samples.GetRange(0, 10);

            }

            return samples;

        }

        


            public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult aboutus()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult blogs()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult drugrecall(string country, string state, string catclass, string typeofrecall)
        {
            typeofrecall = "drug";
            List<Recall> drugRecallData = GetRecalls(country, state, catclass, typeofrecall);
            _repository.SaveRecallData(drugRecallData);
            if (drugRecallData == null)
            {
                RedirectToAction("drugrecall");
            }
            
            return View(drugRecallData);
        }
                
        public IActionResult foodrecall(string country, string state, string catclass, string typeofrecall)
        {
            typeofrecall = "food";
            List<Recall> foodRecallData = GetRecalls(country, state, catclass, typeofrecall);
            _repository.SaveRecallData(foodRecallData);
            if (foodRecallData == null)
            {
                RedirectToAction("foodrecall");

            } 
            return View(foodRecallData);


        }

        public IActionResult displayresults()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
