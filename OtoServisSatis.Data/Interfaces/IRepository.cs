using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(); //Tüm kayıtlar listelenecek.
        List<T> GetAll(Expression<Func<T, bool>> expression);//Expression kullanarak Filtre gönderdik.İçindeki filtreye göre sorgulama yapılır.Filtreye göre Kayıtları listeleriz.
        T Get(Expression<Func<T, bool>> expression);// Bir tane kayıt getiren metot oluşturdum. İçindeki filtreye göre sorgulama yapılır
        T Find(int id);// İlgili id ile eşleşen kaydı getirir.
        void Add(T entity);// Sınıf ekleme işlemleri için oluşturdum.
        void Update(T entity);// Sınıf düzenleme işlemleri için oluşturdum.
        void Delete(T entity);// Sınıf silme işlemleri için oluşturdum.
        int Save();

        // Asenkron Metotlar
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> FindAsync(int id);
        void AddAsync(T entity);
        Task<int> SaveAsync();

    }
}
