namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommittedBlock")]
    public partial class CommittedBlock
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
        public long Offset { get; set; }

        [Required]
        [StringLength(128)]
        public string BlockId { get; set; }

        public long? Length { get; set; }

        public DateTime? BlockVersion { get; set; }

        public virtual Blob Blob { get; set; }
    }
}
