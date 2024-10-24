using GameClubAPI.DatabseContext;
using GameClubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameClubAPI.Services
{
    public class ClubService : IClubService
    {
        private readonly GameClubDbContext context;

        public ClubService(GameClubDbContext context)
        {
            this.context = context;
        }

        public async Task<Club> CreateClub(Club club)
        {
            await context.Clubs.AddAsync(club);
            await context.SaveChangesAsync();
            return club;
        }

        public async Task<Club> GetClubByName(string name)
        {
            return await context.Clubs.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<Club> GetClubById(int Id)
        {
            return await context.Clubs.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Club>> GetAllClubs()
        {
            return await context.Clubs.ToListAsync();
        }

        public async Task<List<Club>> SearchClubs(string? searchText)
        {
            if (searchText != null && searchText != "")
            {
                searchText = searchText.Trim().ToLower();
                return await context.Clubs
                             .Where(c => c.Name.ToLower().Contains(searchText) || c.Description.ToLower().Contains(searchText))
                              .ToListAsync();
            }
            return await GetAllClubs();
        }

        public async Task<Event> CreateEvent(Event newEvent)
        {
            await context.Events.AddAsync(newEvent);
            await context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<List<Event>> GetEventsForClub(int clubId)
        {
            return await context.Events.Where(x=>x.ClubId == clubId).ToListAsync();
        }
    }
}

