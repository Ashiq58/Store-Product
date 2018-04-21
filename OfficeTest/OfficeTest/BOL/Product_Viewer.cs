using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeTest.BOL
{
    public class Product_Viewer
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Price { get; set; }
        public string Product_Description { get; set; }
        public int Brand_Id { get; set; }
        public string Brand_Name { get; set; }
        public int Unit_Id { get; set; }
        public string Unit { get; set; }
    }
   
}