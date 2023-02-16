using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public ApplicationUser? applicationUser { get; set; }
        public Post? post { get; set; }

    }
}
