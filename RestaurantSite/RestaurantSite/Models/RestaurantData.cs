using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantSite.Models
{
    public class RestaurantData
    {
        public int table_id;
        public int table_capacity;
        public bool isoccupied;

        public RestaurantData(int table_id, int table_capacity, bool isoccupied)
        {
            this.table_id = table_id;
            this.table_capacity = table_capacity;
            this.isoccupied = isoccupied;
        }
    }
}