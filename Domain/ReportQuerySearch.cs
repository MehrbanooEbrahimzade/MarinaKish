using Domain.Enums;
using System;

namespace Domain
{
    public class ReportQuerySearch
    {
        public string FunType { get; set;  }
        public WhereBuy WhereBuy { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
