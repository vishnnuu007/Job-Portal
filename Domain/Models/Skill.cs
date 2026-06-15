
namespace Domain.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<JobSeekerProfile> JobSeekerProfiles { get; set; } = new List<JobSeekerProfile>();

    }
}
