using IMIP.Tochu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
            Task<IEnumerable<Comment>> GetAllActiveCommentsAsync(bool active = true);
    }
}
