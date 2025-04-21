using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaundaryManagementSystem.Models
{
    public class StaffQuarter
    {
        public string MemberName { get; set; }

        public string RoomNo { get; set; }
        public string Date { get; set; }

        public string NoOfClothes { get; set; }

        public string MobileNumber { get; set; }    

        public string TypesOfClothes { get; set; }  

        public string Rate { get; set; }

        public string TotalAmount { get; set; }

        public string Operation { get; set; }   

        public string StaffQuarterStatus { get; set; }  

        public  string Gender { get; set; } 

        public string Active { get; set; }  
    }
}