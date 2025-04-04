using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Server.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(200, ErrorMessage ="Company name cannot exceed 200 charactors")]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "Positionis required.")]
        [StringLength(100, ErrorMessage = "Position cannot exceed 100 charactors")]
        public string Position { get; set; }


        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("^(Applied|Interview|Offer|Rejected)$", ErrorMessage = "Status must be Applied, Interview, Offer, or Rejected")]
        public string Status { get; set; } = "Applied";

        [Required]
        [DataType(DataType.Date)]
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
    }
}
