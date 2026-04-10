using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(TochuDBContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Comment>> GetAllActiveCommentsAsync(bool active = true)
        {
            return await _context.Comments
                                 .Where(c => c.IsActive == active)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

      
    }
}