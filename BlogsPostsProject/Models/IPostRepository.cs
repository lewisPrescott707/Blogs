using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogsPostsProject.Models
{
    public interface IPostRepository
    {
        Post Add(Post post);
        Task<Post> AddAsync(Post post);
        int Count();
        Task<int> CountAsync();
        void Delete(Post post);
        Task<int> DeleteAsync(Post post);
        void Dispose();
        Post Find(Expression<Func<Post, bool>> match);
        ICollection<Post> FindAll(Expression<Func<Post, bool>> match);
        Task<ICollection<Post>> FindAllAsync(Expression<Func<Post, bool>> match);
        Task<Post> FindAsync(Expression<Func<Post, bool>> match);
        IQueryable<Post> FindBy(Expression<Func<Post, bool>> predicate);
        Task<ICollection<Post>> FindByAsync(Expression<Func<Post, bool>> predicate);
        Post Get(int id);
        IQueryable<Post> GetAll();
        Task<ICollection<Post>> GetAllAsync();
        IQueryable<Post> GetAllIncluding(params Expression<Func<Post, object>>[] includeProperties);
        Task<Post> GetAsync(int id);
        void Save();
        Task<int> SaveAsync();
        Post Update(Post post, object key);
        Task<Post> UpdateAsync(Post post, object key);
    }
}
