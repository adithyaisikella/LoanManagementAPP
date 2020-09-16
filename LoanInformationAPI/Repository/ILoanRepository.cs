using LoanInformationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanInformationAPI.Repository
{
   public interface ILoanRepository
    {

     LoanDetails  GetLoanDetailsByparam(int roleid, string column,string  param);

        void PutheLoandata(int roleid, LoanHolder loanHolder);
        void PosttheLoandata(int roleid,LoanHolder loanHolder);

    }
}
