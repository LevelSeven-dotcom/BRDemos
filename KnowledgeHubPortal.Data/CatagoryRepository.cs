using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.Data
{
    public class CatagoryRepository : ICatagoryRepository
    {
        private KHPortalDbContext _context;

        public CatagoryRepository(KHPortalDbContext context)
        {
            this._context = context;
        }

        public void Delete(int catagoryId)
        {
            _context.Catagories.Remove(_context.Catagories.Find(catagoryId));
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int catagoryId)
        {
            _context.Catagories.Remove(_context.Catagories.Find(catagoryId));
            await _context.SaveChangesAsync();
        }

        public void Edit(Catagory catagory)
        {
            _context.Catagories.Update(catagory);
            _context.SaveChanges();
        }

        public async Task EditAsync(Catagory catagory)
        {
            _context.Catagories.Update(catagory);
            await _context.SaveChangesAsync();
        }

        public List<Catagory> GetAll()
        {
            return _context.Catagories.ToList();
        }

        public async Task<List<Catagory>> GetAllAsync()
        {
            return await _context.Catagories.ToListAsync();
        }

        public Catagory GetById(int id)
        {
            return _context.Catagories.Find(id);
        }

        public async Task<Catagory> GetByIdAsync(int id)
        {
            return await _context.Catagories.FindAsync(id);
        }

        public void Save(Catagory catagory)
        {
            _context.Catagories.Add(catagory);
            _context.SaveChanges();
        }

        public async Task SaveAsync(Catagory catagory)
        {
            _context.Catagories.Add(catagory);
            await _context.SaveChangesAsync();
        }
    }
}