namespace AdoptAnimal.Data.Models
{
    using AdoptAnimal.Data.Common.Models;

    public class Statistic : BaseDeletableModel<int>
    {
        public int AdvertisementsCount { get; set; }

        public int PetsCount { get; set; }

        public int ArticlesCounts { get; set; }

        public int UsersCounts { get; set; }
    }
}
