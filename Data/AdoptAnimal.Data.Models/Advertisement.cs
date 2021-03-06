namespace AdoptAnimal.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AdoptAnimal.Data.Common.Models;

    public class Advertisement : BaseDeletableModel<int>
    {
        public Advertisement()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(800)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Address { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Pet Pet { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
