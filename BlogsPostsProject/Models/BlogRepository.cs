using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogsPostsProject.Models
{
    public class BlogRepository : IBlogRepository
    {
        protected ForumContext _context;
        public BlogRepository(ForumContext context)
        {
            _context = context;
        }

        public Blog Add(Blog blog)
        {
            _context.Add(blog);
            _context.SaveChanges();
            return blog;
        }

        public async Task<Blog> AddAsync(Blog blog)
        {
            _context.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog blog)
        {
            _context.Remove(blog);
            _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(Blog blog)
        {
            _context.Remove(blog);
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

        public Blog Find(Expression<Func<Blog, bool>> match)
        {
            return _context.Blogs.SingleOrDefault(match);
        }

        public ICollection<Blog> FindAll(Expression<Func<Blog, bool>> match)
        {
            return _context.Blogs.Where(match).ToList();
        }

        public async Task<ICollection<Blog>> FindAllAsync(Expression<Func<Blog, bool>> match)
        {
            return await _context.Blogs.Where(match).ToListAsync();
        }

        public async Task<Blog> FindAsync(Expression<Func<Blog, bool>> match)
        {
            return await _context.Blogs.SingleOrDefaultAsync(match);
        }

        public IQueryable<Blog> FindBy(Expression<Func<Blog, bool>> predicate)
        {
            IQueryable<Blog> query = _context.Blogs.Where(predicate);
            return query;
        }

        public async Task<ICollection<Blog>> FindByAsync(Expression<Func<Blog, bool>> predicate)
        {
            return await _context.Blogs.Where(predicate).ToListAsync();
        }

        public Blog Get(int id)
        {
            return _context.Blogs
                .SingleOrDefault(m => m.BlogId == id);
        }

        public IQueryable<Blog> GetAll()
        {
            return _context.Blogs;
        }

        public async Task<ICollection<Blog>> GetAllAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public IQueryable<Blog> GetAllIncluding(params Expression<Func<Blog, object>>[] includeProperties)
        {
            IQueryable<Blog> queryable = GetAll();
            foreach(Expression<Func<Blog, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<Blog, object>(includeProperty);
            }
            return queryable;
        }

        public async Task<Blog> GetAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Blog Update(Blog blog, object key)
        {
            if (blog == null)
                return null;
            Blog exist = _context.Blogs.Find(key);
            if(exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(blog);
                _context.SaveChanges();
            }
            return exist;
        }

        public async Task<Blog> UpdateAsync(Blog blog, object key)
        {
            if(blog == null)
                return null;
            Blog exist = await _context.Blogs.FindAsync(key);
            if(exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(blog);
                await _context.SaveChangesAsync();
            }
            return exist;
        }
    }
}
