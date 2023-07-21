using EntityFrameworkCore_WithSP_Demo.Entities;

namespace EntityFrameworkCore_WithSP_Demo.Repositories
{
    public interface IPersonService
    {
        public Task<List<Person>> GetPersonListAsync();
        public Task<IEnumerable<Person>> GetPersonByIdAsync(int id);
        public Task<string> AddPersonAsync(Person person);
        public Task<string> UpdatePersonAsync(Person person);
        public Task<string> DeletePersonAsync(int id);
    }
}
