using LoanManagementAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementAPP.Repository
{
 public   interface ILoanLoginRepository
    {
        List<UserDetail> GetUserDetails();

        ActionResult<UserDetail> userDetails();




    }
}
