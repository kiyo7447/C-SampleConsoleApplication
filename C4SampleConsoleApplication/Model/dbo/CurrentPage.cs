namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrentPage")]
    public partial class CurrentPage
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(24)]
        public string AccountName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(63)]
        public string ContainerName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string BlobName { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime VersionTimestamp { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StartOffset { get; set; }

        public long? EndOffset { get; set; }

        public virtual Blob Blob { get; set; }
    }
}
