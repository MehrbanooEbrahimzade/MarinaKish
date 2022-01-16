using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ReportDto
    {
        public int  Date { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set;  }
        public decimal TotalAmount { get; set;  }
    }
}
