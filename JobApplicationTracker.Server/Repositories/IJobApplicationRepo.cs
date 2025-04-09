using JobApplicationTracker.Server.Models;

namespace JobApplicationTracker.Server.Repositories
{
    public interface IJobApplicationRepo
    {
        Task<JobApplication> GetJobApplicationByIdAsync(int jobId);
        Task<IEnumerable<JobApplication>> GetJobApplicationsAsync();
        Task<bool> UpdateJobApplicationAsync(JobApplication jobApplication);
        Task<JobApplication> AddJobApplicationAsync(JobApplication jobApplication);
        Task<PagedResult<JobApplication>> GetPagedApplicationsAsync(int pageSize, int pageNo);
    }
}
