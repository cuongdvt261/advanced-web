namespace Shopping.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderCatagory")]
    public partial class OrderCatagory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CatagoryName { get; set; }
    }
}
