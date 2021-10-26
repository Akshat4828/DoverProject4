using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoProjectLearn.LoginAndRegisterModel;

namespace DemoProjectLearn.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        public virtual DbSet<CustomerModel> customers { get; set; }
        public virtual DbSet<PizzaModel> pizzas { get; set; }
        public DbSet<DemoProjectLearn.LoginAndRegisterModel.LoginModel> LoginModel { get; set; }

    }
}
