using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerSideProject.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CustomerSideProject.Controllers
{
    public class HomeController : Controller
    {
        string baseurl = "http://localhost:51054/";

        //GET
        public async Task<ActionResult> Index()
        {
            List<customers_table> customerdetails = new List<customers_table>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Values");
                if (res.IsSuccessStatusCode)
                {
                    var custresponse = res.Content.ReadAsStringAsync().Result;
                    customerdetails = JsonConvert.DeserializeObject<List<customers_table>>(custresponse);
                }

                return View(customerdetails);

            }

        }

        //GET/id
        public async Task<ActionResult> Viewaftersearch()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Viewaftersearch(int? id)
        {
            customers_table cusdataaftersearch = new customers_table();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Values/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var custresponse = res.Content.ReadAsStringAsync().Result;
                    cusdataaftersearch = JsonConvert.DeserializeObject<customers_table>(custresponse);
                }
                Session["ResultList"] = cusdataaftersearch;
                return RedirectToAction("Viewresult");
            }
        }

        //differene page to view result after search(GET/id)
        public ActionResult Viewresult()
        {
           customers_table cuslist = new customers_table();
            cuslist = Session["ResultList"] as customers_table;

            return View(cuslist);
        }

        //POST

        public async Task<ActionResult> CreateNewCustomer()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewCustomer(customers_table newcus)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var myContent = JsonConvert.SerializeObject(newcus);
                var content = System.Text.Encoding.UTF8.GetBytes(myContent);
                var bytecontent = new ByteArrayContent(content);
                bytecontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage res = await client.PostAsync("api/Values/Post", bytecontent);
                return RedirectToAction("Index");
            }

        }
    }
}