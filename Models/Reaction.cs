using SocialMedia.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public enum ReactionType
    {
        Like,
        Dislike
    }
    public class Reaction
    {
        public int Id { get; set; }
        [Required]
        public ReactionType reactionType { get; set; }
        [Required]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public Post Post { get; set; }

    }
}
