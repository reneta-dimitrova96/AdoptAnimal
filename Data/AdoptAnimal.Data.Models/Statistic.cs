namespace AdoptAnimal.Data.Models
{
    using System;

    using AdoptAnimal.Data.Common.Models;

    public class Statistic : BaseDeletableModel<int>
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int AdvertisementsCount { get; set; }

        public int PetsCount { get; set; }

        public int ArticlesCounts { get; set; }

        public int UsersCounts { get; set; }
    }
}
