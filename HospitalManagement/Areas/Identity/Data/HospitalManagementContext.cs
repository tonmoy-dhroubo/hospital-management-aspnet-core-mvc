using HospitalManagement.Areas.Identity.Data;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Data;

public class HospitalManagementContext : IdentityDbContext<HospitalAdminUser>
{
    public HospitalManagementContext(DbContextOptions<HospitalManagementContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Admission> Admissions { get; set; }
    public DbSet<Capacity> Capacities { get; set; }
    public DbSet<Billing> Billings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


    }
}
