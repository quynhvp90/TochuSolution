using IMIP.Tochu.Application.Interfaces;
using IMIP.Tochu.Application.Mappers;
using IMIP.Tochu.Application.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }

        public async Task<CommentModel> AddComment(CommentModel comment)
        {
            var newComment = new Comment()
            {
                Id = Guid.NewGuid(),
                Content = comment.Content,
                IsActive = true,
            };
            _commentRepository.Add(newComment);
            await _commentRepository.SaveChangesAsync();
            return newComment.Mapping();
        }

        public async Task<bool> Delete(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
                return false;
            _commentRepository.Delete(comment);
            await _commentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<CommentModel>> GetActiveComments()
        {
            var comments = await _commentRepository.GetAllActiveCommentsAsync(true);
            return comments.Select(c => c.Mapping()).ToList();
        }

        public async Task<List<CommentModel>> GetComments()
        {
            var comments = await _commentRepository.GetAllAsync();
            return comments.Select(c => c.Mapping()).ToList();
        }

        public async Task<List<CommentModel>> GetInactiveComments()
        {
            var comments = await _commentRepository.GetAllActiveCommentsAsync(false);
            return comments.Select(c => c.Mapping()).ToList();
        }

        public async Task<CommentModel> Update(CommentModel comment)
        {
            var commentEntity = await _commentRepository.GetByIdAsync(comment.Id);
            commentEntity.Content = comment.Content;
            _commentRepository.Update(commentEntity);
            await _commentRepository.SaveChangesAsync();
            return commentEntity.Mapping();
        }
    }
}
