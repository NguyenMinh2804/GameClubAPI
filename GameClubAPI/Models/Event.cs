using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameClubAPI.Models
{
    public class Event
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(256)]
        public string Description { get; set; }
        [Required]
        public DateTime ScheduledDate { get; set; }
        [JsonIgnore]
        public int? ClubId { get; set; }
        [JsonIgnore]
        public Club? Club { get; set; }
    }
}
