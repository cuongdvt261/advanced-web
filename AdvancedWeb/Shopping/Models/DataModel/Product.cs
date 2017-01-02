namespace Shopping.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Deleted { get; set; }

        public int? Promotion { get; set; }
    }
}
