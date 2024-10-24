using GameClubAPI.Models;

namespace GameClubAPI.Services
{
    public interface IClubService
    {
        public Task<Club> CreateClub(Club club);
        public Task<Club> GetClubByName(string name);
        public Task<Club> GetClubById(int Id);
        public Task<List<Club>> GetAllClubs();
        public Task<List<Club>> SearchClubs(string searchText);
        public Task<Event> CreateEvent(Event newEvent);
        public Task<List<Event>> GetEventsForClub(int clubId);
    }
}
