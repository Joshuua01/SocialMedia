using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
