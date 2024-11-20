using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<LastFourContactResultDto>> GetLastFourContact();
        void CreateContact(CreateContactDto createContactDto);
        void DeleteContact(int id);
        

        Task<GetByIDContactDto> GetContact(int id);
    }
}
