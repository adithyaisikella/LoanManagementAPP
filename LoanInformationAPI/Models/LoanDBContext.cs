using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanInformationAPI.Models
{
    public class LoanDBContext : DbContext
    {

        public LoanDBContext(DbContextOptions<LoanDBContext> options) : base(options)
        {
        }

        public DbSet<LoanDetails> LoanDetails { get; set; }
        public DbSet<LoanHolder> loanHolders { get; set; }

        public DbSet<RoleDescription> RoleDescriptions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanHolder>().HasMany<LoanDetails>(g => g.LoanDetailsList).WithOne(x => x.LoanHolders);
            modelBuilder.Entity<LoanDetails>().HasData(new LoanDetails
            {
                LoanAmount = "230000",
              
                LoanId = "9034",
                LoanTerm = "24 Months",
                LoanType = "HOME Loan"


            });
            modelBuilder.Entity<LoanHolder>().HasData(new LoanHolder
            {
                BorrowerName = "Rajesh",
                LegalDocuments = "House Tax central Govt",
                LoanId = "9034",
                PropertyInformation = "1-1-2,Infopark,Kochi,Kerala-682030"

            });
            modelBuilder.Entity<RoleDescription>().HasData(new RoleDescription
            {
                Roleid = 1,
                RoleType = "Admin"
            }, new RoleDescription
            {
                Roleid =2,
                RoleType = "User"
            });
        }


        
    }
}
