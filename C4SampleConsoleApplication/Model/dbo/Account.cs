namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            BlobContainers = new HashSet<BlobContainer>();
            QueueContainers = new HashSet<QueueContainer>();
            TableContainers = new HashSet<TableContainer>();
        }

        [Key]
        [StringLength(24)]
        public string Name { get; set; }

        [MaxLength(256)]
        public byte[] SecretKey { get; set; }

        public byte[] QueueServiceSettings { get; set; }

        public byte[] BlobServiceSettings { get; set; }

        public byte[] TableServiceSettings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlobContainer> BlobContainers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QueueContainer> QueueContainers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableContainer> TableContainers { get; set; }
    }
}
