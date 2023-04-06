using Hostel.Entities;


namespace Hostel.Business.Abstract
{
    public interface IHostelService
    {
        Task<List<HostelModel>> GetAllHostels();
        Task<HostelModel> GetHostelById(int id);
        Task<HostelModel> GetHostelByName(string name);
        Task<HostelModel> CreateHostel(HostelModel hostel);
        Task<HostelModel> UpdateHostel(HostelModel hostel);
        Task DeleteHostel(int id);
    }
}