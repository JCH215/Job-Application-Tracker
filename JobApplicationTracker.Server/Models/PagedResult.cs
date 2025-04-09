namespace JobApplicationTracker.Server.Models
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T>? Applications { get; set; }
    }
}
