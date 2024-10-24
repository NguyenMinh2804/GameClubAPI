using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace GameClubAPI.Models
{
    public class Club
    {
        public int? Id { get; set; }

        [Required, StringLength(100)]
        public string? Name { get; set; }
        [Required, StringLength(256)]
        public string? Description { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
