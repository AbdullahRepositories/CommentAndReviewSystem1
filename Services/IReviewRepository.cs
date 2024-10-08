﻿using CommentAndReviewSystem1.Models;

namespace CommentAndReviewSystem1.Services
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAll();
        public IEnumerable<Review> GetByPost(int id);
        public Review GetById(int id);
        public Review Add(Review review);
        public Review Update(Review reviewchanges);

        public void Delete(int id);

        public bool Save();

    }
}
