
namespace Api.Models;
using Microsoft.EntityFrameworkCore;
public class LoginContext :DbContext
{ 
    protected readonly IConfiguration Configuration;

    public LoginContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
         options.UseSqlServer(Configuration.GetConnectionString("LoginDb"));       
       
    }
   
    public DbSet<Customer> Customers { get; set; }
    
        

}

