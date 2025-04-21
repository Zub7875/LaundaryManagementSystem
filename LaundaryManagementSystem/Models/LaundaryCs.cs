using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaundaryManagementSystem.Models
{
    public class LaundaryCs
    {
        public string StudentName { get; set; }
        public int RoomNo { get; set; }
        public string SubmissionDate { get; set; }
        public int NoOfClothes { get; set; }
        public string TypeOfClothes { get; set; }
        public int Rate { get; set; }

        public int TotalAmount { get; set; }

        public string Operation { get; set; }
    }
}