namespace Shopping.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Username { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        public bool? Deleted { get; set; }

        public int? UserGroupId { get; set; }

        public int AccessFailedCount { get; set; }
    }
}
