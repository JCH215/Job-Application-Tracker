using JobApplicationTracker.Server.Models;

namespace JobApplicationTracker.Server.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<JobApplication>> GetJobApplicationsAsyn();
        Task<JobApplication> GetJobApplicationByIdAsyn(int Id);
        Task<bool> UpdateJobApplicationAsync(JobApplication jobApplication);
        Task<JobApplication> AddJobApplicationAsync(JobApplication jobApplication);
        Task<PagedResult<JobApplication>> GetPagedApplicationsAsyn(int pageSize, int pageNo);
    }
}
