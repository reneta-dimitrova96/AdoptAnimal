namespace AdoptAnimal.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data;
    using AdoptAnimal.Data.Common.Repositories;
    using AdoptAnimal.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class ArticlesController : Controller
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(
            IDeletableEntityRepository<Article> articlesRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.articlesRepository = articlesRepository;
            this.userManager = userManager;
        }

        // GET: Administration/Articles
        public async Task<IActionResult> Index()
        {
            return this.View(await this.articlesRepository
                .AllWithDeleted()
                .Include(a => a.Author)
                .ToListAsync());
        }

        // GET: Administration/Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var article = await this.articlesRepository.All()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }

        // GET: Administration/Articles/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Article article)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            article.Author = user;

            if (this.ModelState.IsValid)
            {
                await this.articlesRepository.AddAsync(article);
                await this.articlesRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(article);
        }

        // GET: Administration/Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var article = this.articlesRepository.All().FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }

        // POST: Administration/Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Content,AuthorId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Article article)
        {
            if (id != article.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.articlesRepository.Update(article);
                    await this.articlesRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ArticleExists(article.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(article);
        }

        // GET: Administration/Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var article = await this.articlesRepository.All()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }

        // POST: Administration/Articles/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = this.articlesRepository.All().FirstOrDefault(a => a.Id == id);
            this.articlesRepository.Delete(article);
            await this.articlesRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ArticleExists(int id)
        {
            return this.articlesRepository.All().Any(a => a.Id == id);
        }
    }
}
