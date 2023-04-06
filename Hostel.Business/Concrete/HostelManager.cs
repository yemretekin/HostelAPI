using Hostel.Business.Abstract;
using Hostel.DataAccess.Abstract;
using Hostel.Entities;

namespace Hostel.Business.Concrete
{
    public class HostelManager : IHostelService
    {
        private IHostelRepository _hostelRepository;
        public HostelManager(IHostelRepository hostelRepository)
        {
            _hostelRepository = hostelRepository;
        }
        public async Task<HostelModel> CreateHostel(HostelModel hostel)
        {
            return await _hostelRepository.CreateHostel(hostel);
        }

        public async Task DeleteHostel(int id)
        {
            _hostelRepository.DeleteHostel(id);
        }

        public async Task<List<HostelModel>> GetAllHostels()
        {
            return await _hostelRepository.GetAllHostels();
        }

        public async Task<HostelModel> GetHostelById(int id)
        {
            if (id>0)
            {
                return await _hostelRepository.GetHostelById(id);
            }
            throw new Exception("id can not be lass than 1!");
        }

        public async Task<HostelModel> GetHostelByName(string name)
        {
            return await _hostelRepository.GetHostelByName(name);
        }

        public async Task<HostelModel> UpdateHostel(HostelModel hostel)
        {
            return await _hostelRepository.UpdateHostel(hostel);
        }
    }
}