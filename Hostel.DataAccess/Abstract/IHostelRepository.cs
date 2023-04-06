using Hostel.Entities;

namespace Hostel.DataAccess.Abstract;

public interface IHostelRepository
{
    Task<List<HostelModel>> GetAllHostels();
    Task<HostelModel> GetHostelById(int id);
    Task<HostelModel> GetHostelByName(string name);
    Task<HostelModel> CreateHostel(HostelModel hostelModel);
    Task<HostelModel> UpdateHostel(HostelModel hostelModel);
    Task DeleteHostel(int id);   
}
