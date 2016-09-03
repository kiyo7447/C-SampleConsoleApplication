namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QueueMessage")]
    public partial class QueueMessage
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(24)]
        public string AccountName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(63)]
        public string QueueName { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime VisibilityStartTime { get; set; }

        [Key]
        [Column(Order = 3)]
        public Guid MessageId { get; set; }

        public DateTime ExpiryTime { get; set; }

        public DateTime InsertionTime { get; set; }

        public int? DequeueCount { get; set; }

        [Required]
        public byte[] Data { get; set; }

        public virtual QueueContainer QueueContainer { get; set; }
    }
}
