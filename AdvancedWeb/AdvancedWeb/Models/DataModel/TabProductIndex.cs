namespace AdvancedWeb.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TabProductIndex")]
    public partial class TabProductIndex
    {
        [Key]
        public int TabId { get; set; }

        [Required]
        [StringLength(50)]
        public string TabName { get; set; }
    }
}
