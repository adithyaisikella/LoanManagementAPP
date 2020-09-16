
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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace LoanManagementAPP.Controllers
{
    [Route("v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.1")]
    public class UserDetailsController : ControllerBase
    {
        private readonly ILoanLoginRepository loanrepo;

        private readonly ILogger<UserDetailsController> logger;

        public UserDetailsController(ILoanLoginRepository _loanrepo, ILogger<UserDetailsController> _logger)
        {
            this.loanrepo = _loanrepo;
            this.logger = _logger;
        }
        [Authorize(Policy ="PublicSecure")]
        [HttpGet]
        public async Task<ActionResult> GetUser()

        {
            var product = loanrepo.GetUserDetails();
            try
            {

              if(product==null)
                {
  logger.LogError($"USer Details are Empty");
                    return BadRequest();
                }
                return  Ok(await product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving data from the database", product);
                return StatusCode(StatusCodes.Status500InternalServerError);
                   
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
                {
                    logger.LogInformation("Enter Details Are Empty");
                    return BadRequest();
                   
                }
              var k=  loanrepo.CheckuserDetails(user);
                if (k == null && user.UserName == string.Empty)
                    return StatusCode(StatusCodes.Status404NotFound, "User Id Is Invalid ");
                else if (k == null && user.Password == string.Empty)
                    return StatusCode(StatusCodes.Status404NotFound, "PASSWORD Is Invalid");
                else if (k == null)
                {
               
                    return StatusCode(StatusCodes.Status404NotFound, "Invalid Credentials User Id & Password ");
                }
                return StatusCode(StatusCodes.Status200OK,k);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error creating new User record");
            }

        }

        //----circuit breaker


    }
}
