using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // Generic Constraint: T referans tipinde veya IEntity veya IEntity implemente eden bir nesne olabilir 
    // where T : class, IEntity => buradaki class sınıfı değil referans tipi ifade eder
    // new() => newlenebilir olmayı ifade eder new() kullanarak IEntity saf dışı bırakılır
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // Belirli bir datayı çekebilmek için Linq Expression kullanılır
        // Kullanıcı filtreleme istemezse tüm datayı getirebilmesi için filter = null verilir
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
