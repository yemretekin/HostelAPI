using Hostel.DataAccess.Abstract;
using Hostel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hostel.DataAccess.Concrete;

public class HostelRepository : IHostelRepository
{
    public async Task<HostelModel> CreateHostel(HostelModel hostel)
    {
        using (var hostelDbContext = new HostelDbContext())
        {
            hostelDbContext.Hostels.Add(hostel);
            await hostelDbContext.SaveChangesAsync();
            return hostel;
        }
    }

    public async Task DeleteHostel(int id)
    {
        using (var hostelDbContext = new HostelDbContext())
        {
            var deletedHostel = await GetHostelById(id);
            hostelDbContext.Hostels.Remove(deletedHostel);
            await hostelDbContext.SaveChangesAsync();
        }
    }

    public async Task<List<HostelModel>> GetAllHostels()
    {
        using (var hostelDbContext = new HostelDbContext())
        {
            return await hostelDbContext.Hostels.ToListAsync();
        }
    }

    public async Task<HostelModel> GetHostelById(int id)
    {
        using (var hostelDbContext = new HostelDbContext())
        {
            return await hostelDbContext.Hostels.FindAsync(id);
        }
    }

    public async Task<HostelModel> GetHostelByName(string name)
    {
        using (var hostelDbContext = new HostelDbContext())
        {
            return await hostelDbContext.Hostels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }
    }

    public async Task<HostelModel> UpdateHostel(HostelModel hostel)
    {
        using (var hostelDbContext = new HostelDbContext())
        {
            hostelDbContext.Hostels.Update(hostel);
            await hostelDbContext.SaveChangesAsync();
            return hostel;
        }
    }
}