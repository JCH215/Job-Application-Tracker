﻿using JobApplicationTracker.Server.DB;
using JobApplicationTracker.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Server.Repositories
{
    public class JobApplicationRepo : IJobApplicationRepo
    {
        public readonly JobApplicationDbContext DBContext;
        public JobApplicationRepo(JobApplicationDbContext _dbContext) { DBContext = _dbContext; }
        public async Task<JobApplication> AddJobApplicationAsync(JobApplication jobApplication)
        {
            DBContext.JobApplications.Add(jobApplication);
            await DBContext.SaveChangesAsync();

            return jobApplication;
        }

        public async Task<JobApplication> GetJobApplicationByIdAsync(int jobId)
        {
            return await DBContext.JobApplications.FindAsync(jobId);
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationsAsync()
        {
            return await DBContext.JobApplications.ToListAsync();
        }

        public async Task<PagedResult<JobApplication>> GetPagedApplicationsAsync(int pageSize, int pageNo)
        {
            var totalCount = await DBContext.JobApplications.CountAsync();
            var applications = await DBContext.JobApplications.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<JobApplication>()
            {
                TotalCount = totalCount,
                Applications = applications
            };
        }

        public async Task<bool> UpdateJobApplicationAsync(JobApplication jobApplication)
        {
            DBContext.Entry(jobApplication).State = EntityState.Modified;
            return await DBContext.SaveChangesAsync() > 0;
        }
    }
}
