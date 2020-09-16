using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanInformationAPI.Models
{
    public class LoanViewModel
    {
        public string BorrowerName { get; set; }

        public string PropertyInformation { get; set; }

        public string LegalDocuments { get; set; }

        public string LoanId { get; set; }
        public string LoanAmount { get; set; }

        public string LoanTerm { get; set; }
        public string LoanType { get; set; }
       

     

    }
}
