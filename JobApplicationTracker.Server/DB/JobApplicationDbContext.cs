using JobApplicationTracker.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Server.DB
{
    public class JobApplicationDbContext : DbContext
    {
        public JobApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}