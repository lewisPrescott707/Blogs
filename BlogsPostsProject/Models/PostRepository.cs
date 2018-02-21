using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogsPostsProject.Models
{
    public class PostRepository : IPostRepository
    {
        protected ForumContext _context;
        public PostRepository(ForumContext context)
        {
            _context = context;
        }

        public Post Add(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
            return post;
        }

        public async Task<Post> AddAsync(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(Post post)
        {
            _context.Remove(post);
            _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(Post post)
        {
            _context.Remove(post);
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Post Find(Expression<Func<Post, bool>> match)
        {
            return _context.Posts.SingleOrDefault(match);
        }

        public ICollection<Post> FindAll(Expression<Func<Post, bool>> match)
        {
            return _context.Posts.Where(match).ToList();
        }

        public async Task<ICollection<Post>> FindAllAsync(Expression<Func<Post, bool>> match)
        {
            return await _context.Posts.Where(match).ToListAsync();
        }

        public async Task<Post> FindAsync(Expression<Func<Post, bool>> match)
        {
            return await _context.Posts.SingleOrDefaultAsync(match);
        }

        public IQueryable<Post> FindBy(Expression<Func<Post, bool>> predicate)
        {
            IQueryable<Post> query = _context.Posts.Where(predicate);
            return query;
        }

        public async Task<ICollection<Post>> FindByAsync(Expression<Func<Post, bool>> predicate)
        {
            return await _context.Posts.Where(predicate).ToListAsync();
        }

        public Post Get(int id)
        {
            return _context.Posts
                .SingleOrDefault(m => m.PostId == id);
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Posts;
        }

        public async Task<ICollection<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public IQueryable<Post> GetAllIncluding(params Expression<Func<Post, object>>[] includeProperties)
        {
            IQueryable<Post> queryable = GetAll();
            foreach(Expression<Func<Post, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<Post, object>(includeProperty);
            }
            return queryable;
        }

        public async Task<Post> GetAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Post Update(Post post, object key)
        {
            if (post == null)
                return null;
            Post exist = _context.Posts.Find(key);
            if(exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(post);
                _context.SaveChanges();
            }
            return exist;
        }

        public async Task<Post> UpdateAsync(Post post, object key)
        {
            if(post == null)
                return null;
            Post exist = await _context.Posts.FindAsync(key);
            if(exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(post);
                await _context.SaveChangesAsync();
            }
            return exist;
        }
    }
}
