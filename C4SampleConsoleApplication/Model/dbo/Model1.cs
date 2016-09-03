namespace ConsoleApplication
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=Model1")
		{
		}

		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Blob> Blobs { get; set; }
		public virtual DbSet<BlobContainer> BlobContainers { get; set; }
		public virtual DbSet<BlockData> BlockDatas { get; set; }
		public virtual DbSet<CommittedBlock> CommittedBlocks { get; set; }
		public virtual DbSet<CurrentPage> CurrentPages { get; set; }
		public virtual DbSet<Page> Pages { get; set; }
		public virtual DbSet<QueueContainer> QueueContainers { get; set; }
		public virtual DbSet<QueueMessage> QueueMessages { get; set; }
		public virtual DbSet<TableContainer> TableContainers { get; set; }
		public virtual DbSet<TableRow> TableRows { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Blob>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<Blob>()
				.Property(e => e.ContainerName)
				.IsUnicode(false);

			modelBuilder.Entity<Blob>()
				.Property(e => e.ContentType)
				.IsUnicode(false);

			modelBuilder.Entity<Blob>()
				.Property(e => e.ContentMD5)
				.IsFixedLength();

			modelBuilder.Entity<Blob>()
				.HasMany(e => e.CommittedBlocks)
				.WithRequired(e => e.Blob)
				.HasForeignKey(e => new { e.AccountName, e.ContainerName, e.BlobName, e.VersionTimestamp });

			modelBuilder.Entity<Blob>()
				.HasMany(e => e.CurrentPages)
				.WithRequired(e => e.Blob)
				.HasForeignKey(e => new { e.AccountName, e.ContainerName, e.BlobName, e.VersionTimestamp });

			modelBuilder.Entity<Blob>()
				.HasMany(e => e.Pages)
				.WithRequired(e => e.Blob)
				.HasForeignKey(e => new { e.AccountName, e.ContainerName, e.BlobName, e.VersionTimestamp });

			modelBuilder.Entity<BlobContainer>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<BlobContainer>()
				.Property(e => e.ContainerName)
				.IsUnicode(false);

			modelBuilder.Entity<BlobContainer>()
				.HasMany(e => e.Blobs)
				.WithRequired(e => e.BlobContainer)
				.HasForeignKey(e => new { e.AccountName, e.ContainerName });

			modelBuilder.Entity<BlockData>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<BlockData>()
				.Property(e => e.ContainerName)
				.IsUnicode(false);

			modelBuilder.Entity<BlockData>()
				.Property(e => e.BlockId)
				.IsUnicode(false);

			modelBuilder.Entity<CommittedBlock>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<CommittedBlock>()
				.Property(e => e.ContainerName)
				.IsUnicode(false);

			modelBuilder.Entity<CommittedBlock>()
				.Property(e => e.BlockId)
				.IsUnicode(false);

			modelBuilder.Entity<CurrentPage>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<CurrentPage>()
				.Property(e => e.ContainerName)
				.IsUnicode(false);

			modelBuilder.Entity<Page>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<Page>()
				.Property(e => e.ContainerName)
				.IsUnicode(false);

			modelBuilder.Entity<QueueContainer>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<QueueContainer>()
				.Property(e => e.QueueName)
				.IsUnicode(false);

			modelBuilder.Entity<QueueContainer>()
				.HasMany(e => e.QueueMessages)
				.WithRequired(e => e.QueueContainer)
				.HasForeignKey(e => new { e.AccountName, e.QueueName });

			modelBuilder.Entity<QueueMessage>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<QueueMessage>()
				.Property(e => e.QueueName)
				.IsUnicode(false);

			modelBuilder.Entity<TableContainer>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<TableContainer>()
				.Property(e => e.TableName)
				.IsUnicode(false);

			modelBuilder.Entity<TableContainer>()
				.Property(e => e.CasePreservedTableName)
				.IsUnicode(false);

			modelBuilder.Entity<TableContainer>()
				.HasMany(e => e.TableRows)
				.WithRequired(e => e.TableContainer)
				.HasForeignKey(e => new { e.AccountName, e.TableName });

			modelBuilder.Entity<TableRow>()
				.Property(e => e.AccountName)
				.IsUnicode(false);

			modelBuilder.Entity<TableRow>()
				.Property(e => e.TableName)
				.IsUnicode(false);
		}
	}
}
