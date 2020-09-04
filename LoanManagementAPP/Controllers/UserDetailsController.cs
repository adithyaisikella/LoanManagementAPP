using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagementAPP.Models;
using System.Net.Http;
using System.Net;

namespace LoanManagementAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        


        public UserDetailsController(UserDetDataContext context)
        {
            _context = context;
        }


        [HttpGet("GetUser")]
        public List<UserDetail> GetUser()
        {

          
        }

        // POST: api/UserDetailsLogin FOR LOGIN     

        [HttpPost("CheckUserDetails")]
        public ActionResult<UserDetail> CheckUserDetails(UserDetail userDet)
        {
            var x = _context.UserDetailsData.Where(x => x.UserName == userDet.UserName).ToList();

            var y = _context.UserDetailsData.Where(x => x.Password == userDet.Password).ToList();

            if (x == null && y == null)

            {
                return NotFound();
            }

            return Ok(userDet);




        }


    }
}
