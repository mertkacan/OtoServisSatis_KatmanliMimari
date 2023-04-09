using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Data.Interfaces;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.SomutSınıflar
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DatabaseContext _context;

        private readonly DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity); // Gönderilen Class veritabanına eklendi.
        }

        public async void AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity); // Gönderilen Class veritabanına Asenkron olarak eklendi.
        }

        public void Delete(T entity)
        {
          _dbSet.Remove(entity); // Gönderilen Class veritabanından silindi.
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);// Gönderilen id'li veriyi bul dedim.
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);// Gönderilen id'li veriyi bul dedim.
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
           return _dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList(); // Filtreye göre şartı uygula ve Listeyi Döndür dedim.
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await (_dbSet.FirstOrDefaultAsync(expression)); // Filtreye uyan veriyi getir.
        }

        public int Save()
        {
           return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await (_context.SaveChangesAsync());
        }

        public void Update(T entity)
        {
            _context.Update(entity);//Gelen Entity'i güncelle.
        }
    }
}
