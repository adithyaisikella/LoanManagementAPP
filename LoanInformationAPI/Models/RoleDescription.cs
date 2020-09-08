using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanInformationAPI.Models
{
    public class RoleDescription
    {
        [Key]
        public int Roleid { get; set; }
        public string RoleType { get; set; }
    }
}
