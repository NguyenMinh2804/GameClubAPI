using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameClubAPI.Models
{
    public class Club
    {
        [JsonIgnore]
        public int? Id { get; set; }

        [Required, StringLength(100)]
        public string? Name { get; set; }
        [Required, StringLength(256)]
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<Event>? Events { get; set; }
    }
}
