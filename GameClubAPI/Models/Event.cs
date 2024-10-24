using System.ComponentModel.DataAnnotations;

namespace GameClubAPI.Models
{
    public class Event
    {
        public int? Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(256)]
        public string Description { get; set; }
        [Required]
        public DateTime ScheduledDate { get; set; }
        public int? ClubId { get; set; }
        public Club? Club { get; set; }
    }
}
