using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PunkAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PunkAPI.Controllers
{
    public class PunkController : Controller
    {
        public static string rootAPI = "https://api.punkapi.com/v2/beers/";

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Piva> pive = GetAll().Result;


            return View(pive);
        }
        public IActionResult IndexRandom()
        {
            List<Piva> pive = GetRandom().Result;


            return View("Index", pive);
        }

        // GET: /<controller>/
        public IActionResult NameAPI(String NameSearch)
        {
            List<Piva> pive = new List<Piva>();

            if (!String.IsNullOrEmpty(NameSearch))
            {
                pive = GetAllByName(NameSearch).Result;
            }

            return View(pive);
        }

        // GET: /<controller>/
        public IActionResult AgeAPI(String AgeSearch)
        {
            List<Piva> pive = new List<Piva>();

            if (!String.IsNullOrEmpty(AgeSearch))
            {
                pive = GetAllByName(AgeSearch).Result;
            }

            return View(pive);
        }


        public async Task<List<Piva>> GetAll()
        {
            HttpClient hc = new HttpClient();

            HttpResponseMessage response = await hc.GetAsync(rootAPI);
            String dohvat = await response.Content.ReadAsStringAsync();


            List<Piva> pive = JsonConvert.DeserializeObject<List<Piva>>(dohvat);

            return pive;
        }

        public async Task<List<Piva>> GetAllByName(string search)
        {
            HttpClient hc = new HttpClient();

            HttpResponseMessage response = await hc.GetAsync(rootAPI + "?beer_name=" + search);
            String dohvat = await response.Content.ReadAsStringAsync();


            List<Piva> pive = JsonConvert.DeserializeObject<List<Piva>>(dohvat);

            return pive;
        }

        public async Task<List<Piva>> GetAllByAge(string search)
        {
            HttpClient hc = new HttpClient();

            HttpResponseMessage response = await hc.GetAsync(rootAPI + "?brewed_before=" + search);
            String dohvat = await response.Content.ReadAsStringAsync();


            List<Piva> pive = JsonConvert.DeserializeObject<List<Piva>>(dohvat);

            return pive;
        }

        public async Task<List<Piva>> GetRandom()
        {
            HttpClient hc = new HttpClient();

            HttpResponseMessage response = await hc.GetAsync(rootAPI + "random");
            String dohvat = await response.Content.ReadAsStringAsync();

            //JObject piva = JObject.Parse(dohvat);

            List<Piva> piva = JsonConvert.DeserializeObject<List<Piva>>(dohvat);

            return piva;
        }



    }
}
