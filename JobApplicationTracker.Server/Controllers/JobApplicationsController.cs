using JobApplicationTracker.Server.Models;
using JobApplicationTracker.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobApplicationTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IApplicationService ApplicationService;
        public JobApplicationsController(IApplicationService applicationService) {
            ApplicationService = applicationService;
        }

        /// <summary>
        /// List all job applications
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetJobApplicationsAsync()
        {
            var applications = await ApplicationService.GetJobApplicationsAsyn();
            return Ok(applications);
        }

        /// <summary>
        /// List paged applications
        /// </summary>
        /// <param name="pageSize">the number of applicaitons per page</param>
        /// <param name="pageNo">page number</param>
        /// <returns>Applications of given page</returns>
        [HttpGet("{pageSize}/{pageNo}",Name ="paged")]
        public async Task<ActionResult<PagedResult<JobApplication>>> GetPagedApplicationsAsync(int pageSize = 5, int pageNo = 1)
        {
            var result = await ApplicationService.GetPagedApplicationsAsyn(pageSize,pageNo);
            return Ok(result);
        }

        /// <summary>
        /// Get a job application by Id
        /// </summary>
        /// <param name="id">Application Id</param>
        /// <returns>Application details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetById(int id)
        {
            if (id == 0) return BadRequest();

            var application = await ApplicationService.GetJobApplicationByIdAsyn(id);
            if (application == null) { return NotFound(); }

            return Ok(application);
        }


        /// <summary>
        /// Add a new application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] JobApplication application)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdApplication = await ApplicationService.AddJobApplicationAsync(application);
            if (createdApplication == null) return BadRequest(application);

            return CreatedAtAction(nameof(GetById), new { createdApplication.Id }, createdApplication);
        }
        /// <summary>
        /// Update an application (e.g. change status to Intervide/Offer/Rejected.)
        /// </summary>
        /// <param name="id">Application ID</param>
        /// <param name="application">Application details</param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]JobApplication application)
        {
            if(id != application.Id) { return BadRequest(); }

            return await ApplicationService.UpdateJobApplicationAsync(application)? NoContent():NotFound();
        }

    }
}
