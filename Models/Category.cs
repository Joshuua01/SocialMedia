using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public IEnumerable<Post>? Posts { get; set; } = new List<Post>();
    }
}
