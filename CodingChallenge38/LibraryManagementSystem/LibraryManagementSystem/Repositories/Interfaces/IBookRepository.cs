using LibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithDetailsAsync();
        Task<Book> GetByIdWithDetailsAsync(int id);
    }
}
