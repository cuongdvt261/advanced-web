namespace Shopping.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? UserId { get; set; }

        public int? CatagoryId { get; set; }

        public bool? Deleted { get; set; }
    }
}
