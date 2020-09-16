
using LoanInformationAPI.Controllers;
using LoanInformationAPI.Models;
using LoanInformationAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
   public class LoandetailsControllerTest
    {
        LoanDetailsController loanDetailsController;


        Mock<ILoanRepository> mockloanrepo;
        Mock<ILogger<LoanDetailsController>> mocklogger;

        LoanDetails loanDetails;LoanHolder loanHolder;

        public LoandetailsControllerTest()
        {

            mockloanrepo = new Mock<ILoanRepository>();
            mocklogger = new Mock<ILogger<LoanDetailsController>>();
            loanDetailsController = new LoanDetailsController(mockloanrepo.Object, mocklogger.Object);



        }

        [Fact]

        public void ChecktheGetUserDetails()
        {
            int roleid = 1; string column = "LoanId"; string param = "1111";
            LoanDetailsGet();

            mockloanrepo.Setup(x => x.GetLoanDetailsByparam(roleid, column, param)).Returns(loanDetails);

            var res = loanDetailsController.GetLoandetails(roleid, column, param);
            
            Assert.IsType<OkObjectResult>(res.Result);


        }


        [Fact]

        public void ChecktheGetUserEmptyDetails()
        {
            int roleid =0; string column =null; string param =null;


            mockloanrepo.Setup(x => x.GetLoanDetailsByparam(roleid, column, param));

            var res = loanDetailsController.GetLoandetails(roleid, column, param);


            Assert.Equal(res.Value, null);

        }

        //Post Method to Test
        [Fact]

        public void PosttheLoanDetails()
        {
            int roleid =2; LoanDetailsGet(); ReturnsLoanHolders();

            mockloanrepo.Setup(x => x.PosttheLoandata(roleid,loanHolder));

            var res = loanDetailsController.PostLoanDetails(roleid,loanHolder);



            Assert.IsType<StatusCodeResult>(res);



        }
        [Fact]

        public void PosttheLoanDetailsEmpty()
        {
            int roleid =0; LoanHolder loanHolder = null;

            var res = loanDetailsController.PostLoanDetails(roleid, loanHolder);
            Assert.IsType<BadRequestResult>(res);
        }

     

        //UpDate the  Method to Test
        [Fact]

        public void UpdatetheLoanDetails()
        {
            int roleid = 2; LoanDetailsGet(); ReturnsLoanHolders();

            mockloanrepo.Setup(x => x.PosttheLoandata(roleid, loanHolder));

            var res = loanDetailsController.UpdateLoanDetails(roleid, loanHolder);

            Assert.IsType<StatusCodeResult>(res);
        }
        [Fact]

        public void UpdateLoanDetailsEmptyRequest()
        {
            int roleid = 0; LoanHolder loanHolder = null;

            var res = loanDetailsController.UpdateLoanDetails(roleid, loanHolder);



            Assert.IsType<BadRequestResult>(res);



        }





        /// <summary>
        /// Arranging data 
        /// </summary>
        private void LoanDetailsGet()
        {

            loanDetails = new LoanDetails
            {

                LoanId = "1111",
                LoanAmount = "23442",LoanTerm="4 Months",LoanType="Personal",
               LoanHolders = new LoanHolder
                {

                    BorrowerName = "Adithya",
                    LegalDocuments = "Cash transac",
                    LoanId = "1111",
                    PropertyInformation = "3234Acrs"
                },
            
            };
        
        }

        private void ReturnsLoanHolders()
        {

             loanHolder = new LoanHolder
            {

                BorrowerName = "Adithya",
                LegalDocuments = "Cash transac",
                LoanId = "1111",
                PropertyInformation = "3234Acrs",
                LoanDetailsList = new List<LoanDetails>()
                { 
                    new LoanDetails
                    {
                          LoanId = "1111",
                LoanAmount = "23442",LoanTerm="4 Months",LoanType="Personal",
                    }
                
                },
            };

        }







    }
}
