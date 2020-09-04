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
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        UserDetDataContext _context;


        public UserDetailsController(UserDetDataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public List<UserDetail> GetUser()
        {

            return _context.UserDetailsData.ToList();
        }

        // POST: api/UserDetailsLogin FOR LOGIN     

        [HttpPost]
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
