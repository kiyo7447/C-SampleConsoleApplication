namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableContainer")]
    public partial class TableContainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableContainer()
        {
            TableRows = new HashSet<TableRow>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(24)]
        public string AccountName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(63)]
        public string TableName { get; set; }

        public DateTime LastModificationTime { get; set; }

        public byte[] ServiceMetadata { get; set; }

        public byte[] Metadata { get; set; }

        [Required]
        [StringLength(63)]
        public string CasePreservedTableName { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableRow> TableRows { get; set; }
    }
}
