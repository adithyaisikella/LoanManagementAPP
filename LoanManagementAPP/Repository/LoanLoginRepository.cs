using LoanManagementAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace LoanManagementAPP.Repository
{
    public class LoanLoginRepository : ILoanLoginRepository
    {
        private readonly UserDetDataContext _context;

        public LoanLoginRepository(UserDetDataContext context)
        {
            _context = context;
        }

        public List<UserDetail> GetUserDetails()
        {
            return _context.UserDetailsData.ToList();
        }

        public ActionResult<UserDetail> userDetails(UserDetail us) 
        {
           
        }
    }
}
