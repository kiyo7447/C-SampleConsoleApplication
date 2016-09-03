namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlockData")]
    public partial class BlockData
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
        public bool IsCommitted { get; set; }

        [Key]
        [Column(Order = 5)]
        public string BlockId { get; set; }

        public long? Length { get; set; }

        public long StartOffset { get; set; }

        [StringLength(260)]
        public string FilePath { get; set; }
    }
}
