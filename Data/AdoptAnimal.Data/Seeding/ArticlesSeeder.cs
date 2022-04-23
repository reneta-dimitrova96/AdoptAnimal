namespace AdoptAnimal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AdoptAnimal.Data.Models;

    public class ArticlesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Articles.Any())
            {
                return;
            }

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "10 неща за Котките",
                Content = "Котките обичат да бъдат галени и обгрижвани, но не толкова много, колкото например кучетата обичат. Хората с котка за домашен любимец трябва да знаят, че тя не винаги може да е в гальовно настроение и ако има нужда от внимание, сама ще дойде.",
                Source = "https://www.four-paws.bg/nashata-rabota-i-kampanii/kampanii/osinovi-me-statii/10-neshcha-koito-vseki-stopanin-na-kotki-triabva-da-znae",
                ImageUrl = "https://cdn.pixabay.com/photo/2022/01/18/07/38/cat-6946505_960_720.jpg",
            });

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Интересни факти за зайците",
                Content = "Зайците мразят да се къпят, а и не се нуждаят от баня. Изсъхването на козината отнема много  време, а при сушене със сешоар има опасност от привличане на паразити.",
                Source = "https://www.lapichki.com/pets/statii_p.php?id=121",
                ImageUrl = "https://cdn.pixabay.com/photo/2017/07/13/16/10/cute-2500929_960_720.jpg",
            });

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Регистрация на любимци",
                Content = "Ако имате екзотични или диви домашни любимци е важно да знаете, че българското законодателство изисква задължителното им регистриране. Причината е, че така властите осигуряват контрол върху отглежданите животни, а това значително подпомага опазването им, дава възможност да се следят условията на отглеждане и в някои случаи осигурява безопасността на гражданите.",
                Source = "https://www.dnevnik.bg/zelen/stil_na_jivot/2015/06/29/2562950_ekzotichnite_i_divi_domashni_ljubimci_triabva_da_se/",
                ImageUrl = "https://cdn.pixabay.com/photo/2021/08/16/03/27/lorikeet-6549172_960_720.jpg",
            });

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Папагалите са левичари",
                Content = "Австралийски изследователи са установили, че почти всички пернати, които са изследвали, са използвали или предимно лявото си око и лявото краче, или дясното око и дясното краче.",
                Source = "https://m.inews.bg/%D0%9B%D1%8E%D0%B1%D0%BE%D0%BF%D0%B8%D1%82%D0%BD%D0%BE/%D0%9F%D0%B0%D0%BF%D0%B0%D0%B3%D0%B0%D0%BB%D0%B8%D1%82%D0%B5-%D1%81%D0%B0-%D0%BB%D0%B5%D0%B2%D0%B8%D1%87%D0%B0%D1%80%D0%B8-_l.a_c.3992_i.23588.html",
                ImageUrl = "https://cdn.pixabay.com/photo/2019/12/30/05/23/macaw-4728862_960_720.jpg",
            });

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "КУЧЕТО САМО ВКЪЩИ?",
                Content = "Когато е оставен сам за прекалено много време, приятелят Ви може да се почувства самотен и разстроен, така че най-добре е да не го оставяте твърде дълго.",
                Source = "https://www.ceva.bg/Novini-i-Statii/Statii-i-polezna-informaciya/Za-kolko-vreme-mozhete-da-ostavite-kucheto-samo-vk-schi",
                ImageUrl = "https://cdn.pixabay.com/photo/2014/08/21/14/51/dog-423398_960_720.jpg",
            });

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Кучешки гени",
                Content = "Изследователи от Университета в Линчепинг, Швеция, откриха гени, които правят кучетата дружелюбни към хората. Резултатите от проучването бяха публикувани в списание Science Reports.",
                Source = "https://www.actualno.com/curious/otkriha-genite-koito-sprijateljavat-kucheto-s-choveka-news_565978.html",
                ImageUrl = "https://cdn.pixabay.com/photo/2016/01/05/17/51/maltese-1123016_960_720.jpg",
            });
        }
    }
}
