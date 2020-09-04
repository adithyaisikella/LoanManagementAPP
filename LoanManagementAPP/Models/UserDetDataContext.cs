using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementAPP.Models
{
    public class UserDetDataContext : DbContext
    {
        public UserDetDataContext(DbContextOptions<UserDetDataContext> options) : base(options)
        {



        }

        public DbSet<UserDetail> UserDetailsData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().HasData(
                
                new UserDetail() { UserName="Adithya",Password="police",Role="Admin"},
                 new UserDetail() { UserName = "Daya", Password = "rams", Role = "Admin" }


                );


                }
    }
    }
