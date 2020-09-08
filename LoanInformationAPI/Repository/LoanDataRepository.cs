using LoanInformationAPI.Models;
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
        public LoanHolder GetLoanDetailsByparam(int roleid, string param)
        {
            //USER -2 DATA TO SEE THE LOAN DETAILS ON SCREEN
            var x = loanDBContext.RoleDescriptions.Where(x => x.Roleid == roleid).Select(x => x.RoleType).FirstOrDefault();
            if(x==null)
                return null;
            
            else if(x=="User")
           
            {
              var   para1 = loanDBContext.loanHolders.Where(x => x.BorrowerName == param ||x.LoanId==param).FirstOrDefault();
               
                if(para1!=null)
                {
                    var y = loanDBContext.LoanDetails.Where(x => x.LoanId == para1.LoanId).FirstOrDefault();
                    if (y != null)
                        return para1;
                }
                return null;
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

                var k = loanDBContext.loanHolders.FirstOrDefault();
                if (loanHolder != null)
                {
                   k.BorrowerName = loanHolder.BorrowerName;
                    k.LegalDocuments = loanHolder.LegalDocuments;
                    k.LoanDetailsList = loanHolder.LoanDetailsList;
                  
                    k.PropertyInformation = loanHolder.PropertyInformation;
                    loanDBContext.SaveChanges();
                }
            }



        }


    }
}
