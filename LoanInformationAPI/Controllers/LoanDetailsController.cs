using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanInformationAPI.Models;
using LoanInformationAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanInformationAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        private readonly ILoanRepository loanDataRepository;

        public LoanDetailsController(ILoanRepository _loanDataRepository)
        {

            loanDataRepository = _loanDataRepository;
        }

        [HttpGet("{roleid}/{param}")]
        public ActionResult GetLoandetails(int roleid, string param)
        {
            var x = loanDataRepository.GetLoanDetailsByparam(roleid, param);
            if (x == null) return StatusCode(StatusCodes.Status404NotFound, "file not found");
            return Ok(x);

        }

        [HttpPost("{roleid}")]

        public ActionResult PostLoanDetails(int roleid, LoanHolder model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            loanDataRepository.PosttheLoandata(roleid, model);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPut("{roleid}")]

        public ActionResult UpdateLoanDetails(int roleid, LoanHolder model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            loanDataRepository.PutheLoandata(roleid, model);
            return StatusCode(StatusCodes.Status301MovedPermanently);
        }

    }

    }
