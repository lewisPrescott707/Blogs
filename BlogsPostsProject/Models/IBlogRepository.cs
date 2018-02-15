using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogsPostsProject.Models
{
    public interface IBlogRepository
    {
        Blog Add(Blog blog);
        Task<Blog> AddAsynAsync(Blog blog);
        int Count();
        Task<int> CountAsync();
        void Delete(Blog entity);
        Task<int> DeleteAsync(Blog entity);
        void Dispose();
        Blog Find(Expression<Func<Blog, bool>> match);
        ICollection<Blog> FindAll(Expression<Func<Blog, bool>> match);
        Task<ICollection<Blog>> FindAllAsync(Expression<Func<Blog, bool>> match);
        Task<Blog> FindAsync(Expression<Func<Blog, bool>> match);
        IQueryable<Blog> FindBy(Expression<Func<Blog, bool>> predicate);
        Task<ICollection<Blog>> FindByAsync(Expression<Func<Blog, bool>> predicate);
        Blog Get(int id);
        IQueryable<Blog> GetAll();
        Task<ICollection<Blog>> GetAllAsync();
        IQueryable<Blog> GetAllIncluding(params Expression<Func<Blog, object>>[] includeProperties);
        Task<Blog> GetAsync(int id);
        void Save();
        Task<int> SaveAsync();
        Blog Update(Blog blog, object key);
        Task<Blog> UpdateAsync(Blog blog, object key);
    }
}
