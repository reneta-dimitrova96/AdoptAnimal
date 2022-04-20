namespace AdoptAnimal.Web.Controllers
{
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;
    using AdoptAnimal.Services.Data;
    using AdoptAnimal.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        public IActionResult Create(int advertisementId)
        {
            var viewModel = new CreateCommentInputModel
            {
                AdvertisementId = advertisementId,
            };
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.commentsService.CreateAsync(input, user.Id);

            return this.Redirect("/");
        }

        public IActionResult All(int advertisementId)
        {
            var viewModel = new CommentsListViewModel
            {
                Comments = this.commentsService.GetAllCommentsByAdId<CommentViewModel>(advertisementId),
            };
            return this.View(viewModel);
        }
    }
}
