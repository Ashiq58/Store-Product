using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeTest.BOL
{
    public class ProductRcv_Viewer
    {

        public int ProductReceive_Id { get; set; }
        public string MRR_No { get; set; }
        public DateTime Receive_Date { get; set; }
        public  int Receive_Qty { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
    }
}