using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanInformationAPI.Models
{
    public class LoanDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LoanId { get; set; }
        public string LoanAmount { get; set; }

        public string LoanTerm { get; set; }
        public string LoanType { get; set; }

        public virtual  LoanHolder LoanHolders {get;set;}




    }
}
