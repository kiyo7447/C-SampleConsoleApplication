namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blob")]
    public partial class Blob
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blob()
        {
            CommittedBlocks = new HashSet<CommittedBlock>();
            CurrentPages = new HashSet<CurrentPage>();
            Pages = new HashSet<Page>();
        }

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

        public int? BlobType { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long ContentLength { get; set; }

        [StringLength(128)]
        public string ContentType { get; set; }

        public long? ContentCrc64 { get; set; }

        [MaxLength(16)]
        public byte[] ContentMD5 { get; set; }

        public byte[] ServiceMetadata { get; set; }

        public byte[] Metadata { get; set; }

        public Guid? LeaseId { get; set; }

        public long? LeaseDuration { get; set; }

        public DateTime? LeaseEndTime { get; set; }

        public long? SequenceNumber { get; set; }

        public int? LeaseState { get; set; }

        public bool? IsLeaseOp { get; set; }

        public long? MaxSize { get; set; }

        [StringLength(260)]
        public string FileName { get; set; }

        public bool? IsCommitted { get; set; }

        public bool? HasBlock { get; set; }

        public int? UncommittedBlockIdLength { get; set; }

        [StringLength(260)]
        public string DirectoryPath { get; set; }

        public virtual BlobContainer BlobContainer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommittedBlock> CommittedBlocks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurrentPage> CurrentPages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Page> Pages { get; set; }
    }
}
