using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantSite.Models;
namespace RestaurantSite.Controllers
{
    
    public class HomeController : Controller
    {
        List<RestaurantData> restlist;
        public ActionResult Index()
        {
            restlist = new List<RestaurantData>();
            restlist.Add(new RestaurantData(100, 10, false));
            restlist.Add(new RestaurantData(101, 10, false));
            restlist.Add(new RestaurantData(102, 6, false));
            restlist.Add(new RestaurantData(103, 6, false));
            restlist.Add(new RestaurantData(104, 6, false));
            restlist.Add(new RestaurantData(105, 4, false));
            restlist.Add(new RestaurantData(106, 4, false));
            restlist.Add(new RestaurantData(107, 2, false));
            restlist.Add(new RestaurantData(108, 2, false));
            restlist.Add(new RestaurantData(109, 2, false));

            return View(restlist);
        }

        public ActionResult GetDataFromCustomer(int  numberofpersons=12)

        {
            if(areTablesAvailable(numberofpersons))
            {
                AllocateSeats(numberofpersons);
                
            }
            else
            {
                return Content("Tables are not vacant now. Please try after some time.");
            }


            return View();
        }
        public bool areTablesAvailable(int noofppl)
        {
            bool vacancyavailable = false;
            int count=0;
            foreach(var table in restlist)
            {
                if(table.isoccupied==false)
                {
                    count = count + table.table_capacity;
                }
            }
            if (count > noofppl)
            {
                vacancyavailable = true;
            }
            return vacancyavailable;
        }
        public void AllocateSeats(int noofppl)
        {
            int totalppl = noofppl;
            if (totalppl == 1)
            {
                foreach (var table in restlist)
                {
                    if (table.table_capacity == 2)
                    {
                        table.isoccupied = true;
                    }
                }
            }
            else
            {
                while (totalppl > 0)
                {
                    foreach (var table in restlist)
                    {
                        if (table.isoccupied == false)
                        {
                            if (totalppl / table.table_capacity >= 1)
                            {
                                table.isoccupied = true;
                                totalppl = totalppl - table.table_capacity;
                                break;

                            }

                        }

                    }
                }
            }
            
        }
    }
}
