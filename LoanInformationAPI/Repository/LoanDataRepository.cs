using LoanInformationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanInformationAPI.Repository
{
    public class LoanDataRepository : ILoanRepository
    {

        private readonly LoanDBContext loanDBContext;

        public LoanDataRepository(LoanDBContext _loanDB)
        {
            loanDBContext = _loanDB;
        }



        //----Return loan Details 
        public LoanDetails GetLoanDetailsByparam(int roleid, string column, string param)
        {
            var x = loanDBContext.RoleDescriptions.Where(x => x.Roleid == roleid).Select(x => x.RoleType).FirstOrDefault();
            if (x == "User" && (column == "BorrowerName" || column == "LoanId" ||column=="LoanAmount"))

            {

           LoanDetails res = (from a in loanDBContext.loanHolders join c in loanDBContext.LoanDetails on a.LoanId equals c.LoanId  where a.BorrowerName == param || a.LoanId == param || c.LoanAmount== param select c).FirstOrDefault();

                
                return res;
            }
            else return null;
        }

      
      


        //- -----  Create the Loan details with bases of Role "Admin",models are loan Holder%details both
        public  void PosttheLoandata(int roleid, LoanHolder loanHolder)
        {

            var x = loanDBContext.RoleDescriptions.Where(x => x.Roleid == roleid).Select(x => x.RoleType).FirstOrDefault();
            if (x =="Admin")
            {
                 loanDBContext.loanHolders.Add(loanHolder);
                loanDBContext.SaveChanges();
             
            }


                
        }
        public void PutheLoandata(int roleid, LoanHolder loanHolder)
        {

            var x = loanDBContext.RoleDescriptions.Where(x => x.Roleid == roleid).Select(x => x.RoleType).FirstOrDefault();
            if (x == "Admin")
            {
                //loanDBContext.loanHolders.

                var k = loanDBContext.loanHolders.FirstOrDefault(e => e.BorrowerName == loanHolder.BorrowerName);
                    
                if (loanHolder != null)
                {
                  
                    k.LegalDocuments = loanHolder.LegalDocuments;
                    k.LoanDetailsList = loanHolder.LoanDetailsList;
                  
                    k.PropertyInformation = loanHolder.PropertyInformation;
                    loanDBContext.SaveChanges();
                }
            }



        }


    }
}
