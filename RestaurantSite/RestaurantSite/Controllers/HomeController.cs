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
        masterEntities dbobj = new masterEntities();
        List<tabledetail> tablelist;
        public ActionResult Index()
        {
            
            return View(dbobj.tabledetails.ToList());
        }

        public ActionResult GetDataFromCustomer(int  numberofpersons)

        {
            if(areTablesAvailable(numberofpersons))
            {
                AllocateSeats(numberofpersons);
                return RedirectToAction("Index");

            }
            else
            {
                return Content("Tables are not vacant now. Please try after some time.");
               
            }


           
        }
        public bool areTablesAvailable(int noofppl)
        {
            tablelist = dbobj.tabledetails.ToList();
            
            int count=0;
            foreach(var table in tablelist)
            {
                if(table.istableoccupies==false)
                {
                    count = count + table.capaciyoftable;
                }
            }
            if (count >= noofppl)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AllocateSeats(int noofppl)
         {
           
            int totalppl = noofppl;
            
                    foreach (var table in tablelist)
                    {
                        if (table.istableoccupies == false && totalppl / table.capaciyoftable >= 1)
                        {
                            dbobj.sp_updateoccupancystatus(table.table_number);
                            totalppl = totalppl - table.capaciyoftable;
                           

                        }

                        else if(totalppl==1)
                            {foreach (var table1 in tablelist.AsEnumerable().Reverse())
                                {if (table1.istableoccupies == false)
                        {
                            dbobj.sp_updateoccupancystatus(table1.table_number);
                            totalppl = totalppl - table.capaciyoftable;
                            break;
                        }
                            } }}
                    

                    } }}

