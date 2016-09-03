namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableRow")]
    public partial class TableRow
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(24)]
        public string AccountName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(63)]
        public string TableName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string PartitionKey { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(256)]
        public string RowKey { get; set; }

        public DateTime Timestamp { get; set; }

        [Column(TypeName = "xml")]
        public string Data { get; set; }

        public virtual TableContainer TableContainer { get; set; }
    }
}
