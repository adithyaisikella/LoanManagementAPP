using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanInformationAPI.Models
{
    public class LoanHolder
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BorrowerName { get; set; }

        public string PropertyInformation { get; set; }
       
    
          public string LoanId { get; set; }
        [ForeignKey("LoanId")]
        public string LegalDocuments { get; set; }

        public virtual ICollection<LoanDetails> LoanDetailsList { get; set; }




    }
}
