using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanInformationAPI.Models;
using LoanInformationAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Nancy.Json;

namespace LoanInformationAPI.Controllers
{
   
    [Route("v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
   
    public class LoanDetailsController : ControllerBase
    {
        private readonly ILoanRepository loanDataRepository;

        private readonly ILogger<LoanDetailsController> logger;


        public LoanDetailsController(ILoanRepository _loanDataRepository, ILogger<LoanDetailsController> _logger)
        {

            loanDataRepository = _loanDataRepository;
            logger = _logger;
        }

        [HttpGet("{roleid}/{column}/{param}")]
   
       

        public ActionResult<LoanDetails> GetLoandetails(int roleid, string column,string param)
        {

           
            try
            {


                var x = loanDataRepository.GetLoanDetailsByparam(roleid, column,param);
            
         
                
                if (x == null)
                {
                    logger.LogError(" Details are Empty in DataBase");
                    return StatusCode(StatusCodes.Status404NotFound,
                       "NO RESULTS FOUND");
                }

 

                return Ok(x);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving data from the database");
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
          

        }

        [HttpPost("{roleid}")]

        public ActionResult PostLoanDetails(int roleid, LoanHolder model)
        {

            if (model == null) return BadRequest();
            loanDataRepository.PosttheLoandata(roleid, model);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{roleid}")]

        public ActionResult UpdateLoanDetails(int roleid, LoanHolder model)
        {
            if (model == null) return BadRequest();

            loanDataRepository.PutheLoandata(roleid, model);
            return StatusCode(StatusCodes.Status301MovedPermanently);
        }

    }

    }
