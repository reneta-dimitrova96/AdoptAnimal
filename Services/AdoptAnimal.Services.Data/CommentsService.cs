namespace AdoptAnimal.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Mapping;
    using AdoptAnimal.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(
            IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(CreateCommentInputModel input)
        {
            var comment = new Comment
            {
                Content = input.Content,
                AdvertisementId = input.AdvertisementId,
            };
            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllCommentsByAdId<T>(int advertisementId)
        {
            var comments = this.commentsRepository.AllAsNoTracking()
                .Where(c => c.AdvertisementId == advertisementId)
                .To<T>()
                .ToList();
            return comments;
        }

        public int GetCommentsCount()
        {
            return this.commentsRepository.AllAsNoTracking().Count();
        }
    }
}
