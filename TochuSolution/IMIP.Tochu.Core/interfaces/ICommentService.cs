using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentModel>> GetComments();
        Task<List<CommentModel>> GetActiveComments();
        Task<List<CommentModel>> GetInactiveComments();
        Task<bool> Delete(Guid id);
        Task<CommentModel> AddComment(CommentModel comment);
        Task<CommentModel> Update(CommentModel comment);
    }
}
