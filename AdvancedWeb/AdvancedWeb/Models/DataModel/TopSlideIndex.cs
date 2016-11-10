namespace AdvancedWeb.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TopSlideIndex")]
    public partial class TopSlideIndex
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string IntroTop { get; set; }

        public string IntroMid { get; set; }

        public string IntroBottom { get; set; }
    }
}
