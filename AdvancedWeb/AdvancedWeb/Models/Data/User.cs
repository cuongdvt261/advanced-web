namespace AdvancedWeb.Models.Data
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

        [StringLength(288)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnable { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnable { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(26)]
        public string Username { get; set; }
    }
}
