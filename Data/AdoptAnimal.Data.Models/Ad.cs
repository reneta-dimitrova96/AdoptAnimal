namespace AdoptAnimal.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class Ad : BaseDeletableModel<int>
    {
        public Ad()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MinLength(10)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
