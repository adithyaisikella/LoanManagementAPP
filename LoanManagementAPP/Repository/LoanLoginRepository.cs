using LoanManagementAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace LoanManagementAPP.Repository
{
    public class LoanLoginRepository :ILoanLoginRepository
    {
        private readonly UserDetDataContext _context;

        public LoanLoginRepository(UserDetDataContext context)
        {
            _context = context;
        }

        public async Task<UserDetail> AdduserDetail(UserDetail detail)
        {
            var res = await _context.UserDetailsData.AddAsync(detail);

            await _context.SaveChangesAsync();
            return res.Entity;
        
        }

        public   UserDetail CheckuserDetails(UserDetail detail)
        {
            var username = _context.UserDetailsData.Where(x => x.UserName.Equals(detail.UserName)).FirstOrDefault();
            var passw = _context.UserDetailsData.Where(x => x.Password.Equals(detail.Password)).FirstOrDefault();
            var res=_context.UserDetailsData.Where(x => x.UserName.Equals(detail.UserName)&& x.Password.Equals(detail.Password)).FirstOrDefault();

            if (username == null || passw==null)
            {
                return null;
                
            }
            else
            {
               
                return detail;
                    
            }
            return detail;
        }

        public async void DeleteuserDetail(string UserName)
        {
         var res= _context.UserDetailsData.FirstOrDefault(x => x.UserName == UserName);
            if(res!=null)
            {

                _context.UserDetailsData.Remove(res);
                 _context.SaveChangesAsync();
            }

        
        }

        public async Task<UserDetail> GetUserDetailbyId(string UserName)
        {
            return await _context.UserDetailsData.FirstOrDefaultAsync(x => x.UserName == UserName);
        }

        public async Task<IEnumerable<UserDetail>> GetUserDetails()
        {
            return await _context.UserDetailsData.ToListAsync();
        }

        public async Task<UserDetail> UpdateuserDetail(UserDetail detail)
        {
          var res= await _context.UserDetailsData.FirstOrDefaultAsync(x => x.UserName == detail.UserName);
        if(res!=null)
            {              res.Password = detail.Password;res.Roleid = detail.Roleid;
                await _context.SaveChangesAsync();
                return res;
            }
            return null;
    }

        
    }
}
