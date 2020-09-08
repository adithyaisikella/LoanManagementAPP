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
using LoanManagementAPP.Repository;

namespace LoanManagementAPP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly ILoanLoginRepository loanrepo;

        public UserDetailsController(ILoanLoginRepository _loanrepo)
        {
            this.loanrepo = _loanrepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {

            try
            {
                return Ok(await loanrepo.GetUserDetails());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpGet("{username}")]
        public async Task<ActionResult<UserDetail>> GetUserDetailByname(string username)
        {
            var res = await loanrepo.GetUserDetailbyId(username);

            if (res == null) return StatusCode(StatusCodes.Status500InternalServerError,
                    "No data from the database");
            else return Ok(res);
        }


        // POST: UserDetailsLogin FOR LOGIN     

        [HttpPost]
        public async Task<ActionResult<UserDetail>> PostUserDetails(UserDetail userDet)
        {


            try
            {
                if(userDet==null)
                    return BadRequest();
                var res = await loanrepo.AdduserDetail(userDet);
                return  RedirectToAction("GetUser");



            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error creating new User record");
            }

        }

        //---PUT METHOD 

        [HttpPut]
        public async Task<ActionResult<UserDetail>> UpdateUserDetails(UserDetail userDet)
        {


            try
            {
                if (userDet == null)
                    return BadRequest();
                var res = await loanrepo.UpdateuserDetail(userDet);
                return RedirectToAction("GetUser");



            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error occured While Updating User record");
            }

        }


        //--------Delete 

        [HttpDelete("{username}")]
        public async Task<ActionResult<UserDetail>> DeleteUser(string username)
        {
            try
            {
                var k = loanrepo.GetUserDetailbyId(username);
                if(k==null) return StatusCode(StatusCodes.Status204NoContent, "We Cant Deleted Data ");
                loanrepo.DeleteuserDetail(username);

     

                return  StatusCode(StatusCodes.Status200OK,"Deleted Data SuccessFully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }


        //---------Code For Checking Login page using POST

        [HttpPost]
        public async Task<ActionResult<UserDetail>> LoginUserDetails(UserDetail user)
        {


            try
            {
                if (user == null)
                    return BadRequest();
              var k=  loanrepo.CheckuserDetails(user);
                if (k == null&&user.UserName == string.Empty)
                    return StatusCode(StatusCodes.Status404NotFound, "User Id Is Invalid ");
               else if (k == null&& user.Password == string.Empty)
                     return StatusCode(StatusCodes.Status404NotFound, "PASSWORD Is Invalid");
                else if(k==null)
                    return StatusCode(StatusCodes.Status404NotFound, "Invalid Credentials User Id & Password ");
                return StatusCode(StatusCodes.Status200OK,k);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error creating new User record");
            }

        }


    }
}
