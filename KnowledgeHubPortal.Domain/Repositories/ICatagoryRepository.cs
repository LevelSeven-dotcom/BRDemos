using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repositories
{
    public interface ICatagoryRepository
    {
        void Save(Catagory catagory);
        Task SaveAsync(Catagory catagory);

        List<Catagory> GetAll();
        Task<List<Catagory>> GetAllAsync();

        Catagory GetById(int id);
        Task<Catagory> GetByIdAsync(int id);

        void Delete(int catagoryId);
        Task DeleteAsync(int catagoryId);

        void Edit(Catagory catagory);
        Task EditAsync(Catagory catagory);

    }
}