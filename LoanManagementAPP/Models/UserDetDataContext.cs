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
                

                new UserDetail() { UserName="Adithya@gmail.com",Password="police",Roleid="1"},
                 new UserDetail() { UserName = "Daya@gmail.com", Password = "rams", Roleid = "0" }


                );


                }
    }
    }
