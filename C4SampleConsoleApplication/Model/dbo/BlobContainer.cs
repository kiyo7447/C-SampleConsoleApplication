namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlobContainer")]
    public partial class BlobContainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BlobContainer()
        {
            Blobs = new HashSet<Blob>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(24)]
        public string AccountName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(63)]
        public string ContainerName { get; set; }

        public DateTime LastModificationTime { get; set; }

        public byte[] ServiceMetadata { get; set; }

        public byte[] Metadata { get; set; }

        public Guid? LeaseId { get; set; }

        public int? LeaseState { get; set; }

        public long? LeaseDuration { get; set; }

        public DateTime? LeaseEndTime { get; set; }

        public bool? IsLeaseOp { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blob> Blobs { get; set; }
    }
}
