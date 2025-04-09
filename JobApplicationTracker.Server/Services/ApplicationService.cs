using JobApplicationTracker.Server.Models;
using JobApplicationTracker.Server.Repositories;

namespace JobApplicationTracker.Server.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IJobApplicationRepo JobApplicationRepo;
        public ApplicationService(IJobApplicationRepo jobApplicationRepo) { JobApplicationRepo = jobApplicationRepo; }
        public async Task<JobApplication> AddJobApplicationAsync(JobApplication jobApplication)
        {            
            return await JobApplicationRepo.AddJobApplicationAsync(jobApplication);
        }

        public async Task<JobApplication> GetJobApplicationByIdAsyn(int Id)
        {
            return await JobApplicationRepo.GetJobApplicationByIdAsync(Id);
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationsAsyn()
        {
            return await JobApplicationRepo.GetJobApplicationsAsync();
        }

        public async Task<PagedResult<JobApplication>> GetPagedApplicationsAsyn(int pageSize, int pageNo)
        {
            return await JobApplicationRepo.GetPagedApplicationsAsync(pageSize, pageNo);
        }

        public async Task<bool> UpdateJobApplicationAsync(JobApplication jobApplication)
        {
            return await JobApplicationRepo.UpdateJobApplicationAsync(jobApplication);
        }
    }
}
