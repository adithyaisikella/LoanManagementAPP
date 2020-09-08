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
       Task<IEnumerable<UserDetail>> GetUserDetails();

        Task<UserDetail> GetUserDetailbyId(string UserName);

        Task<UserDetail> AdduserDetail(UserDetail detail);
        
        Task<UserDetail> UpdateuserDetail(UserDetail detail);
        void DeleteuserDetail(string UserName);

       UserDetail  CheckuserDetails(UserDetail detail);




    }
}
