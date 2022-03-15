namespace AdoptAnimal.Data.Models
{
    using AdoptAnimal.Data.Common.Models;

    public class Statistic : BaseDeletableModel<int>
    {
        public int CountOfViews { get; set; }

        public int CountOfComments { get; set; }

        public int AdvertisementId { get; set; }

        public virtual Advertisement Advertisement { get; set; }
    }
}
