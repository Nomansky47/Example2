namespace Example2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Marriages
    {
        [Key]
        public int MarriageID { get; set; }

        [StringLength(20)]
        public string HusbandPassportNumber { get; set; }

        [StringLength(20)]
        public string WifePassportNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MarriageDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DivorceDate { get; set; }

        public virtual Citizens Citizens { get; set; }
    }
}
