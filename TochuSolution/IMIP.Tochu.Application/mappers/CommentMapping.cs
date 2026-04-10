using IMIP.Tochu.Application.Models;
using IMIP.Tochu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Mappers
{
    public static class CommentMapping
    {
        public static CommentModel Mapping(this Comment comment)
        {
            return new CommentModel
            {
                Id = comment.Id,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt,
                Content = comment.Content
            };
        }
        public static void UpdateMapping(this Comment commentEntity, CommentModel model)
        {
            commentEntity.Content = model.Content;
            commentEntity.CreatedAt = model.CreatedAt;
            commentEntity.UpdatedAt = model.UpdatedAt;
        }
    }
}
